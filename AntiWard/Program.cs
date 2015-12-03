using System;
using System.Collections.Generic;
using System.Linq;
using Ensage;
using SharpDX;
using Ensage.Common;

namespace AntiWard
{
    class Program
    {
        private static bool _loaded;
        private static readonly Dictionary<string, ParticleEffect> Effect = new Dictionary<string, ParticleEffect>();
        private static readonly Dictionary<string, ParticleEffect> Effect2 = new Dictionary<string, ParticleEffect>();
        private static readonly Dictionary<string, ParticleEffect> Effect3 = new Dictionary<string, ParticleEffect>();
        private static readonly Dictionary<string, ParticleEffect> Effect4 = new Dictionary<string, ParticleEffect>();
        private const string EffectPath = @"particles\world_environmental_fx\candle_flame.vpcf";
        private static Vector3[] spot1;
        private static Vector3[] spot2;
        private static Player[] player;

        static void Main(string[] args)
        {
            _loaded = false;
            Game.OnFireEvent += Game_OnFireEvent;
        }

        private static void Game_OnFireEvent(FireEventEventArgs args)
        {
            if (args.GameEvent.Name == "dota_inventory_changed")
            {
                #region gambar
                for (var i = 0; i < 10; i++)
                {
                    ParticleEffect effect;
                    Vector2 screen;

                    if (Drawing.WorldToScreen(spot1[i], out screen))
                    {
                        var first = new Vector3(spot1[i].X + 50, spot1[i].Y, 500);
                        var second = new Vector3(spot2[i].X - 50, spot2[i].Y, 500);
                        if (!Effect.ContainsKey(string.Format("{0} / {1}", i, 1)))
                        {
                            effect = new ParticleEffect(EffectPath,
                                first);
                            effect.SetControlPoint(0, first);
                            Effect.Add(string.Format("{0} / {1}", i, 1), effect);
                        }
                        if (!Effect2.ContainsKey(string.Format("{0} / {1}", i, 1)))
                        {
                            effect = new ParticleEffect(EffectPath,
                                second);
                            effect.SetControlPoint(0, second);
                            Effect2.Add(string.Format("{0} / {1}", i, 1), effect);
                        }

                        var firsty = new Vector3(spot1[i].X, spot1[i].Y - 50, 500);
                        var secondy = new Vector3(spot2[i].X, spot2[i].Y + 50, 500);
                        if (!Effect3.ContainsKey(string.Format("{0} / {1}", i, 1)))
                        {
                            effect = new ParticleEffect(EffectPath,
                                first);
                            effect.SetControlPoint(0, firsty);
                            Effect3.Add(string.Format("{0} / {1}", i, 1), effect);
                        }
                        if (!Effect4.ContainsKey(string.Format("{0} / {1}", i, 1)))
                        {
                            effect = new ParticleEffect(EffectPath,
                                secondy);
                            effect.SetControlPoint(0, secondy);
                            Effect4.Add(string.Format("{0} / {1}", i, 1), effect);
                        }

                    }
                    else
                    {
                        if (Effect.TryGetValue(string.Format("{0} / {1}", i, 1), out effect))
                        {
                            effect.Dispose();
                            Effect.Remove(string.Format("{0} / {1}", i, 1));
                        }
                        if (Effect2.TryGetValue(string.Format("{0} / {1}", i, 1), out effect))
                        {
                            effect.Dispose();
                            Effect2.Remove(string.Format("{0} / {1}", i, 1));
                        }

                        if (Effect3.TryGetValue(string.Format("{0} / {1}", i, 1), out effect))
                        {
                            effect.Dispose();
                            Effect3.Remove(string.Format("{0} / {1}", i, 1));
                        }
                        if (Effect4.TryGetValue(string.Format("{0} / {1}", i, 1), out effect))
                        {
                            effect.Dispose();
                            Effect4.Remove(string.Format("{0} / {1}", i, 1));
                        }
                    }

                }
                #endregion
            }


            throw new NotImplementedException();
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            #region cek
            var me = ObjectMgr.LocalHero;
            if (!_loaded)
            {
                if (!Game.IsInGame || me == null)
                {
                    return;
                }
                _loaded = true;
                PrintSuccess("Antiward nyala");
            }
            if (!Game.IsInGame || me == null)
            {
                _loaded = false;
                PrintInfo("Antiward mati");
                Effect.Clear();
                Effect2.Clear();
                Effect3.Clear();
                Effect4.Clear();
                return;
            }
            if (!Game.IsInGame || !_loaded || !Utils.SleepCheck("Refer")) return;
            Utils.Sleep(500, "Refer");
            #endregion
            for (int i = 0; i < 10; i++)
            {
                player[i] = ObjectMgr.GetPlayerById((uint)i);
                spot1[i].X = player[i].Position.X - 25;
                spot1[i].Y=player[i].Position.Y + 25;
                spot2[i].X = player[i].Position.X + 25;
                spot2[i].Y = player[i].Position.Y - 25;
            }
            #region gambar
            for (var i = 0; i < 10; i++)
            {
                ParticleEffect effect;
                Vector2 screen;

                if (Drawing.WorldToScreen(spot1[i], out screen))
                {
                        var first = new Vector3(spot1[i].X+50, spot1[i].Y, 500);
                        var second = new Vector3(spot2[i].X - 50, spot2[i].Y, 500);
                    if (!Effect.ContainsKey(string.Format("{0} / {1}", i, 1)))
                        {
                            effect = new ParticleEffect(EffectPath,
                                first);
                            effect.SetControlPoint(0, first);
                            Effect.Add(string.Format("{0} / {1}", i, 1), effect);
                        }
                    if (!Effect2.ContainsKey(string.Format("{0} / {1}", i, 1)))
                    {
                        effect = new ParticleEffect(EffectPath,
                            second);
                        effect.SetControlPoint(0, second);
                        Effect2.Add(string.Format("{0} / {1}", i, 1), effect);
                    }

                        var firsty = new Vector3(spot1[i].X, spot1[i].Y - 50, 500);
                        var secondy = new Vector3(spot2[i].X, spot2[i].Y + 50, 500);
                        if (!Effect3.ContainsKey(string.Format("{0} / {1}", i, 1)))
                        {
                            effect = new ParticleEffect(EffectPath,
                                first);
                            effect.SetControlPoint(0, firsty);
                            Effect3.Add(string.Format("{0} / {1}", i, 1), effect);
                        }
                        if (!Effect4.ContainsKey(string.Format("{0} / {1}", i, 1)))
                        {
                            effect = new ParticleEffect(EffectPath,
                                secondy);
                            effect.SetControlPoint(0, secondy);
                            Effect4.Add(string.Format("{0} / {1}", i, 1), effect);
                        }
                    
                }
                else
                {
                        if (Effect.TryGetValue(string.Format("{0} / {1}", i, 1), out effect))
                        {
                            effect.Dispose();
                            Effect.Remove(string.Format("{0} / {1}", i, 1));
                        }
                        if (Effect2.TryGetValue(string.Format("{0} / {1}", i,1), out effect))
                        {
                            effect.Dispose();
                            Effect2.Remove(string.Format("{0} / {1}", i, 1));
                        }

                        if (Effect3.TryGetValue(string.Format("{0} / {1}", i, 1), out effect))
                        {
                            effect.Dispose();
                            Effect3.Remove(string.Format("{0} / {1}", i, 1));
                        }
                        if (Effect4.TryGetValue(string.Format("{0} / {1}", i, 1), out effect))
                        {
                            effect.Dispose();
                            Effect4.Remove(string.Format("{0} / {1}", i, 1));
                        }
                }

            }
            #endregion
            throw new NotImplementedException();
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            var me = ObjectMgr.LocalHero;
            #region cekload
            if (!_loaded)
            {
                if (!Game.IsInGame || me == null)
                {
                    return;
                }
                _loaded = true;
                PrintSuccess("Antiward nyala bro..");
            }
            if (!Game.IsInGame || me == null)
            {
                _loaded = false;
                PrintInfo("Antiward mati.....");
                return;
            }
            if (!Game.IsInGame || !_loaded) return;
            #endregion
            for (var i = 0; i < 10; i++)
            {
                Vector2 screen;
                if (Drawing.WorldToScreen(spot1[i], out screen))
                {
                    Vector2 size;
                    if (Drawing.WorldToScreen(spot2[i], out size))
                    {
                        Drawing.DrawRect(screen, size - screen, Color.AliceBlue);
                    }
                    //Drawing.DrawRect(screen, size-size,
                    //Color.Red);//Spots[i, 2] - Spots[i, 0], Spots[i, 3] - Spots[i, 1]
                    // Drawing.DrawRect(new Vector2(200, 200), new Vector2(200, 200), Color.Red);
                }
            }
        }
        #region print
        public static void PrintInfo(string text, params object[] arguments)
        {
            PrintEncolored(text, ConsoleColor.White, arguments);
        }
        public static void PrintSuccess(string text, params object[] arguments)
        {
            PrintEncolored(text, ConsoleColor.Green, arguments);
        }
        public static void PrintError(string text, params object[] arguments)
        {
            PrintEncolored(text, ConsoleColor.Red, arguments);
        }
        public static void PrintEncolored(string text, ConsoleColor color, params object[] arguments)
        {
            var clr = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text, arguments);
            Console.ForegroundColor = clr;
        }
        #endregion
    }
}
