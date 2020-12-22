using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koursach_Tri_v_Ryad
{
    public class GameLogic
    {
        Element[,] gamefield = new Element[w, w];
        int X = -1;
        int Y = -1;

        const int w = 8;
        const int nulltipe = -99;
        int gamefield1 = -1;
        int gamefield2 = -1;
        bool gamefieldzamena;
        public int score { get; set; }

        List<Element> SovpadEl = new List<Element>();

        Random rng = new Random();

        public GameLogic(Element[,] gamefield)
        {
            this.gamefield = gamefield;
        }

        public int getScore()
        {
            return score;
        }

        public void moveCell(int i, int j)
        {
            SovpadEl.Clear();            

            if ((X == -1) && (Y == -1))
            {
                X = i;
                Y = j;
                gamefield1 = gamefield[i, j].typeofpic;
            }
            else
            {
                if (((X == i) && (Math.Abs(Y - j) == 1)) || ((Y == j) && (Math.Abs(X - i) == 1)))
                {
                    gamefield2 = gamefield[i, j].typeofpic;                   

                    gamefield[X, Y].typeofpic = gamefield2;
                    gamefield[i, j].typeofpic = gamefield1;

                    List<Element> row = TriVRyad();
                    if (row.Count() != 0)
                    {
                        TriVRyad();
                        //FallCells();
                        score += row.Count() * 5;
                    }

                    gamefieldzamena = true;
                }
                else
                {
                    gamefieldzamena = false;
                }

                if (gamefieldzamena == true)
                {
                    //else
                    //{
                    //    gamefield[X, Y].typeofpic = gamefield1;
                    //    gamefield[i, j].typeofpic = gamefield2;
                    //}

                    X = -1;
                    Y = -1;

                    gamefield1 = -1;
                    gamefield2 = -1;

                    //gamefieldzamena = false;
                }              
            }
            //return TriVRyad();
        }

        public List<Element> TriVRyad()
        {            
            SovpadEl.Clear();

            int count;
            
            Element el = gamefield[0, 0];
            Element el1 = gamefield[0, 0];

            for (int i = 0; i < w; i++)
            {
                count = 0;
                //el = gamefield[0, 0];
                for (int j = 0; j < w; j++)
                {
                    if (count == 0)
                    {
                        el = gamefield[i, j];
                        count = 1;
                    }
                    else if (count == 1)
                    {
                        if (gamefield[i, j].typeofpic == el.typeofpic)
                        {
                            //SovpadEl.Add(el);
                            el1 = gamefield[i, j];
                            count++;
                        }
                        else
                        {
                            el = gamefield[i, j];
                            count = 1;
                        }
                    }
                    else if (count > 1)
                    {
                        if (gamefield[i, j].typeofpic == el1.typeofpic)
                        {
                            SovpadEl.Add(el);
                            SovpadEl.Add(el1);
                            SovpadEl.Add(gamefield[i, j]);
                        }
                        else
                        {
                            el = gamefield[i, j];
                            count = 1;
                        }
                            
                    }
                }
            }
            for (int j = 0; j < w; j++)
            {
                count = 0;               
                for (int i = 0; i < w; i++)
                {
                    if (count == 0)
                    {
                        el = gamefield[i, j];
                        count = 1;
                    }
                    else if (count == 1)
                    {
                        if (gamefield[i, j].typeofpic == el.typeofpic)
                        {
                            el1 = gamefield[i, j];
                            count++;
                        }
                        else
                        {
                            el = gamefield[i, j];
                            count = 1;
                        }
                    }
                    else if (count > 1)
                    {
                        if (gamefield[i, j].typeofpic == el1.typeofpic)
                        {
                            SovpadEl.Add(el);
                            SovpadEl.Add(el1);
                            SovpadEl.Add(gamefield[i, j]);
                        }
                        else
                        {
                            el = gamefield[i, j];
                            count = 1;
                        }

                    }
                }
            }

            

                foreach (Element elem in SovpadEl)
                {
                    elem.typeofpic = nulltipe;
                    score += SovpadEl.Count() * 5;
            }
            

            return SovpadEl;

            #region Попытка реализации поиска и удаления похожих элементов
            //for (int i = 0; i < w; i++)
            //{
            //    for (int j = 0; j < w; j++)
            //    {
            //        LineX[j] = gamefield[i, j];
            //    }

            //    int count = 0;

            //    for (int x = 0; x < w; x++)
            //    {
            //        if (count == 0)
            //        {
            //            el = LineX[x];
            //            m = LineX[x].typeofb;
            //            count++;
            //        }
            //        else if (count < 3)
            //        {
            //            if (m == LineX[x].typeofb)
            //            {
            //                count++;
            //                SovpadEl.Add(el);
            //                SovpadEl.Add(LineX[x]);
            //            }
            //            else
            //            {
            //                count = 1;
            //                m = LineX[x].typeofb;
            //                el = LineX[x];
            //            }
            //        }
            //        else if (count > 2)
            //        {
            //            if (m == LineX[x].typeofb)
            //            {
            //                m = LineX[x].typeofb;
            //                SovpadEl.Add(LineX[x]);
            //            }
            //        }
            //    }
            //}

            //for (int j = 0; j < w; j++)
            //{
            //    for (int i = 0; i < w; i++)
            //    {
            //        LineY[i] = gamefield[i, j];
            //    }

            //    int count = 0;

            //    for (int x = 0; x < w; x++)
            //    {
            //        if (count == 0)
            //        {
            //            el = LineY[x];
            //            m = LineY[x].typeofb;
            //            count++;
            //        }
            //        else if (count < 3)
            //        {
            //            if (m == LineY[x].typeofb)
            //            {
            //                count++;
            //                SovpadEl.Add(el);
            //                SovpadEl.Add(LineY[x]);
            //            }
            //            else
            //            {
            //                count = 1;
            //                m = LineY[x].typeofb;
            //                el = LineY[x];
            //            }
            //        }
            //        else if (count > 2)
            //        {
            //            if (m == LineY[x].typeofb)
            //            {
            //                m = LineY[x].typeofb;
            //                SovpadEl.Add(LineY[x]);
            //            }
            //        }
            //    }
            //}
            //foreach (Element elementS in SovpadEl)
            //    elementS.typeofb = 9;
            #endregion

            #region Попытка реализации № 2
            //for (int i = 0; i < w; i++)
            //    for (int j = 0; j < w; j++)
            //    {
            //        if (count == 0)
            //        {
            //            el = gamefield[i, j];
            //            count = 1;
            //            m = gamefield[i, j].typeofb;
            //        }
            //        if ((count > 0) && (count < 2))
            //        {
            //            if (m == gamefield[i, j].typeofb)
            //            {
            //                SovpadEl.Add(gamefield[i, j]);
            //                SovpadEl.Add(gamefield[i + 1, j + 1]);
            //                SovpadEl.Add(gamefield[i + 2, j + 2]);
            //            }
            //        }


            //    }
            #endregion

            #region Попытка №3
            //for (int i = 0; i < w; i++)
            //{
            //    int count = 0;

            //    for (int j = 0; j < w; j++)
            //    {
            //        if (count == 0)
            //        {
            //            el = gamefield[i, j];
            //            m = el.typeofb;
            //            count = 1;
            //        }
            //        if ((count > 0)&&(count < 2))
            //        {
            //            if (el.typeofb == gamefield[i, j].typeofb)
            //            {
            //                count++;
            //                SovpadEl.Add(el);
            //                SovpadEl.Add(gamefield[i, j]);
            //                el = gamefield[i, j];
            //            }
            //            else
            //            {
            //                count = 1;
            //                m = gamefield[i, j].typeofb;
            //                el = gamefield[i, j];
            //            }
            //        }
            //        if (count > 2)
            //        {
            //            if (el.typeofb == gamefield[i, j].typeofb)
            //            {
            //                SovpadEl.Add(gamefield[i, j]);
            //                el = gamefield[i, j];
            //            }

            //        }
            //    }

            //}

            //for (int j = 0; j < w; j++)
            //{
            //    int count = 0;

            //    for (int i = 0; i < w; i++)
            //    {
            //        if (count == 0)
            //        {
            //            el = gamefield[i, j];
            //            //m = el.typeofb;
            //            count = 1;
            //        }
            //        if ((count > 0) && (count < 2))
            //        {
            //            if (el.typeofb == gamefield[i, j].typeofb)
            //            {
            //                count++;
            //                SovpadEl.Add(el);
            //                SovpadEl.Add(gamefield[i, j]);
            //                el = gamefield[i, j];
            //            }
            //            else
            //            {
            //                count = 1;
            //                //m = gamefield[i, j].typeofb;
            //                el = gamefield[i, j];
            //            }
            //        }
            //        if (count > 2)
            //        {
            //            if (el.typeofb == gamefield[i, j].typeofb)
            //            {
            //                SovpadEl.Add(gamefield[i, j]);
            //                el = gamefield[i, j];
            //            }

            //        }
            //    }

            //}
            //foreach (Element elementS in SovpadEl)
            //    elementS.typeofb = 9;
            #endregion

            #region Попытка 4 аааааааааааа
            //for (int i = 0; i < w; i++)
            //{
            //    for (int j = 0; j < w; j++)
            //    {
            //        if (count == 0)
            //        {
            //            el = gamefield[i, j];
            //            m = gamefield[i, j].typeofb;
            //            count = 1;
            //        }
            //        else if ((count != 0) && (count < 3))
            //        {
            //            if (m == gamefield[i, j].typeofb)
            //            {
            //                count++;
            //                SovpadEl.Add(el);
            //                SovpadEl.Add(gamefield[i, j]);
            //                el = gamefield[i, j];
            //            }
            //            else
            //            {
            //                count = 1;
            //                m = gamefield[i, j].typeofb;
            //                el = gamefield[i, j];
            //            }
            //        }
            //        else if (count > 2)
            //        {
            //            if (m == gamefield[i, j].typeofb)
            //            {
            //                //m = gamefield[i, j].typeofb;
            //                SovpadEl.Add(gamefield[i, j]);
            //            }
            //        }
            //    }

            //    count = 0;
            //    m = -1;

            //    for (int j = 0; j < w; j++)
            //    {
            //        for (int i1 = 0; i1 < w; i1++)
            //        {
            //            if (count == 0)
            //            {
            //                el = gamefield[i1, j];
            //                m = gamefield[i1, j].typeofb;
            //                count = 1;
            //            }
            //            else if ((count != 0) && (count < 3))
            //            {
            //                if (m == gamefield[i1, j].typeofb)
            //                {
            //                    count++;
            //                    SovpadEl.Add(el);
            //                    SovpadEl.Add(gamefield[i1, j]);
            //                    el = gamefield[i1, j];
            //                }
            //                else
            //                {
            //                    count = 1;
            //                    m = gamefield[i1, j].typeofb;
            //                    el = gamefield[i1, j];
            //                }
            //            }
            //            else if (count > 2)
            //            {
            //                if (m == gamefield[i1, j].typeofb)
            //                {
            //                    //m = gamefield[i, j].typeofb;
            //                    SovpadEl.Add(gamefield[i1, j]);
            //                }
            //            }
            //        }
            //        count = 0;
            //        m = -1;
            //    }
            //}

            //foreach (Element elementS in SovpadEl)
            //    elementS.typeofb = 9;
            #endregion
        }

        public bool Hasnullpic()
        {
            bool hasnull = false;

            for (int j = w - 1; j >= 0; j--)
            {
                for (int i = w - 2; i >= 0; i--)
                {
                    if (gamefield[i + 1, j].typeofpic == nulltipe)
                    {
                        hasnull = true;
                    }
                    else
                    {
                        hasnull = false;
                    }
                    break;
                }
                break;
            }
            return hasnull;
        }

        public void FallCells()
        {
            int typeel = -1;

            //bool hasnullpics = Hasnullpic();

            //while(hasnullpics == true)
            //{
                for (int j = w - 1; j >= 0; j--)
                {
                    for (int i = w - 2; i >= 0; i--)
                    {
                        if (gamefield[i + 1, j].typeofpic == nulltipe)
                        {
                            typeel = gamefield[i, j].typeofpic;

                            gamefield[i + 1, j].typeofpic = typeel;
                            gamefield[i, j].typeofpic = nulltipe;
                        }
                    }
                }
                for (int j = 0; j < w; j++)
                    for (int i = 0; i < w; i++)
                    {
                        if (gamefield[i, j].typeofpic == nulltipe)
                        {
                            gamefield[i, j].typeofpic = rng.Next(0, 6);
                        }
                        break;
                    }
                //hasnullpics = Hasnullpic();
            //}
            
                
        }
    }
}
