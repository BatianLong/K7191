﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rules
{
    /// <summary>
    /// 验证所出牌组是否符合游戏规则
    /// </summary>
    public static bool IsRules(PokerGroup leadPokers) //判断所出牌组类型以及其是否符合规则
    {
        bool isRule = false;
        Player.sort(leadPokers);
        switch (leadPokers.Count)
        {
            case 0:
                isRule = false;
                break;
            case 1:
                isRule = true;
                leadPokers.type = PokerGroupType.单张;
                break;
            case 2:
                if (IsSame(leadPokers, 2))
                {
                    isRule = true;
                    leadPokers.type = PokerGroupType.对子;
                }
                else
                {
                    if (leadPokers[0] == PokerNum.大王 && leadPokers[1] == PokerNum.小王)
                    {
                        leadPokers.type = PokerGroupType.双王;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                }
                break;
            case 3:
                if (IsSame(leadPokers, 3))
                {
                    leadPokers.type = PokerGroupType.三张相同;
                    isRule = true;
                }
                else
                {
                    isRule = false;
                }
                break;
            case 4:
                if (IsSame(leadPokers, 4))
                {
                    leadPokers.type = PokerGroupType.炸弹;
                    isRule = true;
                }
                else
                {
                    if (IsThreeLinkPokers(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.三带一;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                }
                break;
            case 5:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.五张顺子;
                    isRule = true;
                }
                else
                {
                    isRule = false;
                }
                break;
            case 6:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.六张顺子;
                    isRule = true;
                }
                else
                {
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.三连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsSame(leadPokers, 4))
                        {
                            leadPokers.type = PokerGroupType.四带二;
                            isRule = true;
                        }
                        else
                        {
                            if (IsThreeLinkPokers(leadPokers))
                            {
                                leadPokers.type = PokerGroupType.二连飞机;
                                isRule = true;
                            }
                            else
                            {
                                isRule = false;
                            }
                        }
                    }
                }
                break;
            case 7:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.七张顺子;
                    isRule = true;
                }
                else
                {
                    isRule = false;
                }
                break;
            case 8:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.八张顺子;
                    isRule = true;
                }
                else
                {
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.四连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.飞机带翅膀;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                }
                break;
            case 9:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.九张顺子;
                    isRule = true;
                }
                else
                {
                    if (IsThreeLinkPokers(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.三连飞机;
                    }
                    else
                    {
                        isRule = false;
                    }
                }
                break;
            case 10:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.十张顺子;
                    isRule = true;
                }
                else
                {
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.五连对;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                }
                break;
            case 11:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.十一张顺子;
                    isRule = true;
                }
                else
                {
                    isRule = false;
                }
                break;
            case 12:
                if (IsStraight(leadPokers))
                {
                    leadPokers.type = PokerGroupType.十二张顺子;
                    isRule = true;
                }
                else
                {
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.六连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            //12有三连飞机带翅膀和四连飞机两种情况,所以在IsThreeLinkPokers中做了特殊处理,此处不用给type赋值.
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                }
                break;
            case 13:
                isRule = false;
                break;
            case 14:
                if (IsLinkPair(leadPokers))
                {
                    leadPokers.type = PokerGroupType.七连对;
                    isRule = true;
                }
                else
                {
                    isRule = false;
                }
                break;
            case 15:
                if (IsThreeLinkPokers(leadPokers))
                {
                    leadPokers.type = PokerGroupType.五连飞机;
                    isRule = true;
                }
                else
                {
                    isRule = false;
                }
                break;
            case 16:
                if (IsLinkPair(leadPokers))
                {
                    leadPokers.type = PokerGroupType.八连对;
                    isRule = true;
                }
                else
                {
                    if (IsThreeLinkPokers(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.四连飞机带翅膀;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                }
                break;
            case 17:
                isRule = false;
                break;
            case 18:
                if (IsLinkPair(leadPokers))
                {
                    leadPokers.type = PokerGroupType.六连对;
                    isRule = true;
                }
                else
                {
                    if (IsThreeLinkPokers(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.六连飞机;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                }
                break;
            case 19:
                isRule = false;
                break;
            case 20:
                if (IsLinkPair(leadPokers))
                {
                    leadPokers.type = PokerGroupType.十连对;
                    isRule = true;
                }
                else
                {
                    if (IsThreeLinkPokers(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.五连飞机带翅膀;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                }
                break;
        }
        return isRule;
    }
    /// <summary>
    /// 判断一个牌组指定数量相邻的牌是否两两相同
    /// </summary>
    /// <param name="PG">牌组对象</param>
    /// <param name="amount">指定数量的相邻牌组</param>
    /// <returns>指定数量的相邻牌是否两两相同</returns>
    public static bool IsSame(PokerGroup PG, int amount)
    {
        bool IsSame1 = false;
        bool IsSame2 = false;
        for (int i = 0; i < amount - 1; i++) //从大到小比较相邻牌是否相同
        {
            if (PG[i] == PG[i + 1])
            {
                IsSame1 = true;
            }
            else
            {
                IsSame1 = false;
                break;
            }
        }
        for (int i = PG.Count - 1; i > PG.Count - amount; i--)  //从小到大比较相邻牌是否相同
        {
            if (PG[i] == PG[i - 1])
            {
                IsSame2 = true;
            }
            else
            {
                IsSame2 = false;
                break;
            }
        }
        if (IsSame1 || IsSame2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 判断牌组是否为顺子
    /// </summary>
    /// <param name="PG">牌组</param>
    /// <returns>是否为顺子</returns>
    public static bool IsStraight(PokerGroup PG)
    {
        bool IsStraight = false;
        foreach (Poker poker in PG)//不能包含2、小王、大王
        {
            if (poker == PokerNum.P2 || poker == PokerNum.小王 || poker == PokerNum.大王)
            {
                IsStraight = false;
                return IsStraight;
            }
        }
        for (int i = 0; i < PG.Count - 1; i++)
        {
            if (PG[i].pokerNum - 1 == PG[i + 1].pokerNum)
            {
                IsStraight = true;
            }
            else
            {
                IsStraight = false;
                break;
            }
        }
        return IsStraight;
    }
    /// <summary>
    /// 判断牌组是否为连对
    /// </summary>
    /// <param name="PG">牌组</param>
    /// <returns>是否为连对</returns>
    public static bool IsLinkPair(PokerGroup PG)
    {
        bool IsLinkPair = false;
        foreach (Poker poker in PG) //不能包含2、小王、大王
        {
            if (poker == PokerNum.P2 || poker == PokerNum.小王 || poker == PokerNum.大王)
            {
                IsLinkPair = false;
                return IsLinkPair;
            }
        }
        for (int i = 0; i < PG.Count - 2; i += 2)  //首先比较是否都为对子，再比较第一个对子的点数-1是否等于第二个对子，最后检察最小的两个是否为对子（这里的for循环无法检测到最小的两个，所以需要拿出来单独检查）
        {
            if (PG[i] == PG[i + 1] && PG[i].pokerNum - 1 == PG[i + 2].pokerNum && PG[i + 2] == PG[i + 3])
            {
                IsLinkPair = true;
            }
            else
            {
                IsLinkPair = false;
                break;
            }
        }
        return IsLinkPair;
    }
    /// <summary>
    /// 判断牌组是否为连续三张牌,飞机,飞机带翅膀
    /// </summary>
    /// <param name="PG">牌组</param>
    /// <returns>是否为连续三张牌</returns>
    public static bool IsThreeLinkPokers(PokerGroup PG) //判断三张牌方法为判断两两相邻的牌,如果两两相邻的牌相同,则count自加1.最后根据count的值判断牌的类型为多少个连续三张
    {
        bool IsThreeLinkPokers = false;
        int HowMuchLinkThree = 0;  //飞机的数量
        PG = SameThreeSort(PG); //排序,把飞机放在前面
        for (int i = 2; i < PG.Count; i++)  //得到牌组中有几个飞机
        {
            if (PG[i] == PG[i - 1] && PG[i] == PG[i - 2])
            {
                HowMuchLinkThree++;
            }
        }
        if (HowMuchLinkThree > 0)  //当牌组里面有三个时
        {
            if (HowMuchLinkThree > 1)  //当牌组为飞机时
            {
                for (int i = 0; i < HowMuchLinkThree * 3 - 3; i += 3) //判断飞机之间的点数是否相差1
                {
                    if (PG[i] != PokerNum.P2 && PG[i].pokerNum - 1 == PG[i + 3].pokerNum) //2点不能当飞机出
                    {
                        IsThreeLinkPokers = true;
                    }
                    else
                    {
                        IsThreeLinkPokers = false;
                        break;
                    }
                }
            }
            else
            {
                IsThreeLinkPokers = true; //牌组为普通三个,直接返回true
            }
        }
        else
        {
            IsThreeLinkPokers = false;
        }
        if (HowMuchLinkThree == 4)
        {
            PG.type = PokerGroupType.四连飞机;
        }
        if (HowMuchLinkThree == 3 && PG.Count == 12)
        {
            PG.type = PokerGroupType.三连飞机带翅膀;
        }
        return IsThreeLinkPokers;

    }
    /// <summary>
    /// 对飞机和飞机带翅膀进行排序,把飞机放在前面,翅膀放在后面.
    /// </summary>
    /// <param name="PG">牌组</param>
    /// <returns>是否为连续三张牌</returns>
    public static PokerGroup SameThreeSort(PokerGroup PG)
    {
        Poker FourPoker = null;  //如果把4张当三张出并且带4张的另外一张,就需要特殊处理,这里记录出现这种情况的牌的点数.
        bool FindedThree = false;  //已找到三张相同的牌
        PokerGroup tempPokerGroup = new PokerGroup();  //记录三张相同的牌
        int count = 0; //记录在连续三张牌前面的翅膀的张数
        int Four = 0; // 记录是否连续出现三三相同,如果出现这种情况则表明出现把4张牌(炸弹)当中的三张和其他牌配成飞机带翅膀,并且翅膀中有炸弹牌的点数.
                      // 比如有如下牌组: 998887777666 玩家要出的牌实际上应该为 888777666带997,但是经过从大到小的排序后变成了998887777666 一不美观,二不容易比较.
        for (int i = 2; i < PG.Count; i++)  //直接从2开始循环,因为PG[0],PG[1]的引用已经存储在其他变量中,直接比较即可
        {
            if (PG[i] == PG[i - 2] && PG[i] == PG[i - 1])// 比较PG[i]与PG[i-1],PG[i]与PG[i-2]是否同时相等,如果相等则说明这是三张相同牌
            {
                if (Four >= 1) //默认的Four为0,所以第一次运行时这里为false,直接执行else
                               //一旦连续出现两个三三相等,就会执行这里的if
                {
                    FourPoker = PG[i]; //当找到四张牌时,记录下4张牌的点数
                    Poker changePoker;
                    for (int k = i; k > 0; k--) //把四张牌中的一张移动到最前面.
                    {
                        changePoker = PG[k];
                        PG[k] = PG[k - 1];
                        PG[k - 1] = changePoker;
                    }
                    count++; //由于此时已经找到三张牌,下面为count赋值的程序不会执行,所以这里要手动+1
                }
                else
                {
                    Four++; //记录本次循环,因为本次循环找到了三三相等的牌,如果连续两次找到三三相等的牌则说明找到四张牌(炸弹)
                    tempPokerGroup.Add(PG[i]); //把本次循环的PG[i]记录下来,即记录下三张牌的点数
                }
                FindedThree = true; //标记已找到三张牌
            }
            else
            {
                Four = 0; //没有找到时,连续找到三张牌的标志Four归零
                if (!FindedThree) //只有没有找到三张牌时才让count增加.如果已经找到三张牌,则不再为count赋值.
                {
                    count = i - 1;
                }
            }
        }
        foreach (Poker tempPoker in tempPokerGroup)  //迭代所有的三张牌点数
        {
            Poker changePoker;  //临时交换Poker
            for (int i = 0; i < PG.Count; i++)  //把所有的三张牌往前移动
            {
                if (PG[i] == tempPoker)  //当PG[i]等于三张牌的点数时
                {
                    if (PG[i] == FourPoker) //由于上面已经把4张牌中的一张放到的最前面,这张牌也会与tempPoker相匹配所以这里进行处理
                                            // 当第一次遇到四张牌的点数时,把记录四张牌的FourPoker赋值为null,并中断本次循环.由于FourPoker已经为Null,所以下次再次遇到四张牌的点数时会按照正常情况执行.
                    {
                        FourPoker = null;
                        continue;
                    }
                    changePoker = PG[i - count];
                    PG[i - count] = PG[i];
                    PG[i] = changePoker;
                }
            }
        }
        return PG;
    }
    public static bool operator >(PokerGroup LP, PokerGroup RP)
    {
        bool IsGreater = false;
        if (LP.type != RP.type && LP.type != PokerGroupType.炸弹 && LP.type != PokerGroupType.双王)
        {
            IsGreater = false;
        }
        else
        {
            if (LP.type == PokerGroupType.炸弹 && RP.type == PokerGroupType.炸弹) //LPRP都为炸弹
            {
                if (LP[0] > RP[0]) //比较大小
                {
                    IsGreater = true;
                }
                else
                {
                    IsGreater = false;
                }
            }
            else
            {
                if (LP.type == PokerGroupType.炸弹) //只有LP为炸弹
                {
                    IsGreater = true;
                }
                else
                {
                    if (LP.type == PokerGroupType.双王) //LP为双王
                    {
                        IsGreater = true;
                    }
                    else
                    {
                        if (LP[0] > RP[0]) //LP为普通牌组
                        {
                            IsGreater = true;
                        }
                        else
                        {
                            IsGreater = false;
                        }
                    }
                }
            }
        }
        return IsGreater;
    }
    public void SendOrder(int Num)
    {
        switch (Num)
        {
            case 1:
                DConsole.player1.areYouLandLord = true; //把叫地主权限给自己
                break;
            case 2:
                this.SendDataForClient("AreYouLandLord", 1);  //传递叫地主权限给client1
                break;
            case 3:
                this.SendDataForClient("AreYouLandLord", 2); //传递叫地主权限给client2
                break;
        }
    }
    public void AcceptServerData()
    {
        NetworkStream Ns = client.GetStream();
        string str = "";
        while (true)
        {
            byte[] bytes = new byte[108];
            Ns.Read(bytes, 0, 108);
            str = Encoding.Default.GetString(bytes);
            (省略一部分)
                if (str.StartsWith("AreYouLandLord")) //如果服务器向客户端发送该消息,则客户端获取叫地主权限
            {
                DConsole.player1.areYouLandLord = true; //timer控件检测到该属性值为true时显示出叫地主和不叫按钮
                continue;
            }
            if (str.StartsWith("LandLordPokers")) //获取服务器发送给客户端的地主的3张牌,收到这三张牌后地主权限的传递就结束了
            {
                PokerGroup pokers = new PokerGroup();
                str = str.Replace("LandLordPokers", "");
                byte[] bytePg = Encoding.Default.GetBytes(str);
                pokers.GetPokerGroup(bytePg);
                DConsole.LandLordPokers = pokers;//把接收到的地主牌保存起来
                DConsole.player1.SelectLandLordEnd();//该方法在窗口中央显示出地主牌,然后判断自己是不是地主,如果是地主就将地主牌添加到自己的牌组.该方法的具体代码请看下文
                continue;
            }
            if (str.StartsWith("ClientIsLandLord")) //另外一个客户端是地主
            {
                DConsole.lblClient2Name.Text += "(地主)";
                DConsole.lblClient2Name.ForeColor = System.Drawing.Color.Red;
                DConsole.PaintClient(20);
                continue;
            }
            if (str.StartsWith("ServerIsLandLord")) //服务器是地主
            {
                DConsole.lblClient1Name.Text += "(地主)";
                DConsole.lblClient1Name.ForeColor = System.Drawing.Color.Red;
                DConsole.PaintServer(20);
                continue;
            }
            (后面省略)
            }
    }
}
