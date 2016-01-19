using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventure
{
    class Program
    {
        private static int[] RTEXT = new int[101];
        private static object[,] LLINE = new object[1001,23];
        private static Random RAN = new Random();

        static void Main(string[] args)
        {
            // Adventures                                                                   //C ADVENTURES
                                                                                            //        IMPLICIT INTEGER(A-Z)
                                                                                            //        REAL RAN
                                                                                            //        COMMON RTEXT,LLINE
            int[] IOBJ = new int[301];                                                      //        DIMENSION IOBJ(300),ICHAIN(100),IPLACE(100)
            int[] ICHAIN = new int[101];
            int[] IPLACE = new int[101];
            int[] IFIXED = new int[101];                                                    //        1 ,IFIXED(100),COND(300),PROP(100),ABB(300),LLINE(1000,22)
            int[] COND = new int[301];
            int[] PROP = new int[101];
            int[] ABB = new int[301];
            int[] LTEXT = new int[301];                                                     //        2 ,LTEXT(300),STEXT(300),KEY(300),DEFAULT(300),TRAVEL(1000)
            int[] STEXT = new int[301];
            int[] KEY = new int[301];
            int[] DEFAULT = new int[301];
            int[] TRAVEL = new int[1001];
            int[] TK = new int[26];                                                         //        3 ,TK(25),KTAB(1000),ATAB(1000),BTEXT(200),DSEEN(10)
            int[] KTAB = new int[1001];
            string[] ATAB = new string[1001];
            int[] BTEXT = new int[201];
            int[] DSEEN = new int[11];
            int[] DLOC = new int[11];                                                       //        4 ,DLOC(10),ODLOC(10),DTRAV(20),RTEXT(100),JSPKT(100)
            int[] ODLOC = new int[11];
            int[] DTRAV = new int[21];
            int[] JSPKT = new int[101];
            int[] IPLT = new int[101];                                                      //        5 ,IPLT(100),IFIXT(100)
            int[] IFIXT = new int[101];
                                                                                            //
                                                                                            //C READ THE PARAMETERS
                                                                                            //
            int SETUP = 0;
            int KEYS = 0;
            int LAMP = 0;
            int GRATE = 0;
            int ROD = 0;
            int BIRD = 0;
            int NUGGET = 0;
            int SNAKE = 0;
            int FOOD = 0;
            int WATER = 0;
            int AXE = 0;
            int K = 0;
            int LOLD = 0;
            int JVERB = 0;

            if (SETUP != 0) goto g1;                                                        //        IF(SETUP.NE.0) GOTO 1
            SETUP = 1;                                                                      //        SETUP=1
            KEYS = 1;                                                                       //        KEYS=1
            LAMP = 2;                                                                       //        LAMP=2
            GRATE = 3;                                                                      //        GRATE=3
            ROD = 5;                                                                        //        ROD=5
            BIRD = 7;                                                                       //        BIRD=7
            NUGGET = 10;                                                                    //        NUGGET=10
            SNAKE = 11;                                                                     //        SNAKE=11
            FOOD = 19;                                                                      //        FOOD=19
            WATER = 20;                                                                     //        WATER=20
            AXE = 21;                                                                       //        AXE=21
            Array.Copy(new int[] { 0, 24, 29, 0, 31, 0, 31, 38, 38, 42, 42, 43, 46, 77, 71  //        DATA(JSPKT(I),I=1,16)/24,29,0,31,0,31,38,38,42,42,43,46,77,71
                                   , 73, 75 }, JSPKT, 17);                                  //        1 ,73,75/
            Array.Copy(new int[] {0, 3, 3, 8, 10, 11, 14, 13, 9, 15, 18, 19, 17, 27, 28, 29 //        DATA(IPLT(I),I=1,20)/3,3,8,10,11,14,13,9,15,18,19,17,27,28,29
                                    , 30, 0, 0, 3, 3}, IPLT, 21);                           //        1 ,30,0,0,3,3/
            Array.Copy(new int[] {0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0   //        DATA(IFIXT(I),I=1,20)/0,0,1,0,0,1,0,1,1,0,1,1,0,0,0,0,0,0,0,0/
                                    , 0, 0}, IFIXT, 21);
            Array.Copy(new int[] {0, 36, 28, 19, 30, 62, 60, 41, 27, 17, 15, 19, 28, 36     //        DATA(DTRAV(I),I=1,15)/36,28,19,30,62,60,41,27,17,15,19,28,36
                                    ,300,300 }, DTRAV, 16);                                 //        1 ,300,300/
            for (int i = 1; i < 301; ++i) {                                                 //        DO 1001 I=1,300
                STEXT[i] = 0;                                                               //        STEXT(I)=0
                if (i < 201) BTEXT[i] = 0;                                                  //        IF(I.LE.200) BTEXT(I)=0
                if (i < 101) RTEXT[i] = 0;                                                  //        IF(I.LE.100)RTEXT(I)=0
                LTEXT[i] = 0;                                                               //1001    LTEXT(I)=0
            }
            int I = 1;                                                                      //        I=1
            var f1 = File.OpenText("advdat.txt");                                           //        CALL IFILE(1,'TEXT')
     g1002: int IKIND = int.Parse(f1.ReadLine()??"");                                       //1002    READ(1,1003) IKIND
                                                                                            //1003    FORMAT(G)
            switch(IKIND+1) {                                                               //        GOTO(1100,1004,1004,1013,1020,1004,1004)(IKIND+1)
                case 1:
                    goto g1100; break;
                case 2:
                    goto g1004; break;
                case 3:
                    goto g1004; break;
                case 4:
                    goto g1013; break;
                case 5:
                    goto g1020; break;
                case 6:
                    goto g1004; break;
                case 7:
                    goto g1004; break;
            }
     g1004: var line = f1.ReadLine() ?? "";
            var match = Regex.Match(line, "(-*\\d+)\\s*");                                  //1004    READ(1,1005)JKIND,(LLINE(I,J),J=3,22)
            line = line.Substring(match.Groups[0].Length);                                  //1005    FORMAT(1G,20A5)
            int JKIND = int.Parse(match.Groups[0].Value);
            var matches = Regex.Matches((line), ".{0,5}");
            int J = 3;
            Debug.WriteLine("read strings");
            foreach (Match aMatch in matches)
            {
                LLINE[I, J] = aMatch.Groups[0].Value;
                Debug.Write(LLINE[I, J]);
                J += 1;
            }
            Debug.WriteLine(".");
                                                                                            
            if(JKIND==-1) goto g1002;                                                       //        IF(JKIND.EQ.-1) GOTO 1002
            int KK = 1;
            for (int k=1;k<21;++k) {                                                        //        DO 1006 K=1,20
                KK = k;                                                                     //        KK=K
                if (LLINE[I, 21-k] != null) goto g1007;                                     //        IF(LLINE(I,21-K).NE.' ') GOTO 1007
            }                                                                               //1006    CONTINUE
                                                                                            //        STOP
     g1007: LLINE[I,2] = 20-KK+1;                                                           //1007    LLINE(I,2)=20-KK+1
            LLINE[I, 1] = 0;                                                                //        LLINE(I,1)=0
            if (IKIND == 6) goto g1023;                                                     //        IF(IKIND.EQ.6)GOTO 1023
            if (IKIND == 5) goto g1011;                                                     //        IF(IKIND.EQ.5)GOTO 1011
            if (IKIND == 1) goto g1008;                                                     //        IF(IKIND.EQ.1) GOTO 1008
            if (STEXT[JKIND] != 0) goto g1009;                                              //        IF(STEXT(JKIND).NE.0) GOTO 1009
            STEXT[JKIND] = I;                                                               //        STEXT(JKIND)=I
            goto g1010;                                                                     //        GOTO 1010
                                                                                            //
     g1008: if (LTEXT[JKIND] != 0) goto g1009;                                              //1008    IF(LTEXT(JKIND).NE.0) GOTO 1009
            LTEXT[JKIND] = I;                                                               //        LTEXT(JKIND)=I
            goto g1010;                                                                     //        GOTO 1010
     g1009: LLINE[I-1,1] = I;                                                               //1009    LLINE(I-1,1)=I
     g1010: I=I+1;                                                                          //1010    I=I+1
            if (I != 1000) goto g1004;                                                      //        IF(I.NE.1000)GOTO 1004
            Debug.WriteLine("too many lines");                                              //        PAUSE 'TOO MANY LINES'
                                                                                            //
     g1011: if(JKIND<200) goto g1012;                                                       //1011    IF(JKIND.LT.200)GOTO 1012
            if(BTEXT[JKIND-100]!=0) goto g1009;                                             //        IF(BTEXT(JKIND-100).NE.0)GOTO 1009
            BTEXT[JKIND - 100] = I;                                                         //        BTEXT(JKIND-100)=I
            BTEXT[JKIND - 200] = I;                                                         //        BTEXT(JKIND-200)=I
            goto g1010;                                                                     //        GOTO 1010
     g1012: if(BTEXT[JKIND]!=0) goto g1009;                                                 //1012    IF(BTEXT(JKIND).NE.0)GOTO 1009
            BTEXT[JKIND] = I;                                                               //        BTEXT(JKIND)=I
            goto g1010;                                                                     //        GOTO 1010
                                                                                            //
     g1023: if(RTEXT[JKIND] != 0) goto g1009;                                               //1023    IF(RTEXT(JKIND).NE.0) GOTO 1009
            RTEXT[JKIND] = I;                                                               //        RTEXT(JKIND)=I
            goto g1010;                                                                     //        GOTO 1010
                                                                                            //
     g1013: I=1;                                                                            //1013    I=1
     g1014: line = f1.ReadLine() ?? "";                                                     //1014    READ(1,1015)JKIND,LKIND,(TK(L),L=1,10)
            matches = Regex.Matches(line, "-*\\d+\\s*");                                    //1015    FORMAT(12G)
            Debug.WriteLine("read number line");
            foreach (Match aMatch in matches)
                Debug.Write(aMatch.Value);
            Debug.WriteLine(".");
            JKIND=Int32.Parse(matches[0].Value);
            if (JKIND == -1) goto g1002;
            int LKIND=Int32.Parse(matches[1].Value);
            for (int l = 1; l <= 10; ++l)
            {
                if (l < matches.Count - 1)
                    TK[l] = Int32.Parse(matches[l+1].Value);
                else
                    TK[l] = 0;
            }
                                                                                            //        IF(JKIND.EQ.-1) GOTO 1002
            if (KEY[JKIND] != 0) goto g1016;                                                //        IF(KEY(JKIND).NE.0) GOTO 1016
            KEY[JKIND] = I;                                                                 //        KEY(JKIND)=I
            goto g1017;                                                                     //        GOTO 1017
     g1016: TRAVEL[I-1]=-TRAVEL[I-1];                                                       //1016    TRAVEL(I-1)=-TRAVEL(I-1)
     g1017: for(int l = 1; l<=10; ++l)                                                      //1017    DO 1018 L=1,10
            {
                if(TK[l]==0) goto g1019;                                                    //        IF(TK(L).EQ.0) GOTO 1019
                TRAVEL[I] = LKIND*1024+TK[l];                                               //        TRAVEL(I)=LKIND*1024+TK(L)
                I=I+1;                                                                      //        I=I+1
                if(I==1000) return;                                                         //        IF(I.EQ.1000) STOP
            }                                                                               //1018    CONTINUE
     g1019: TRAVEL[I-1]=-TRAVEL[I-1];                                                       //1019    TRAVEL(I-1)=-TRAVEL(I-1)
            goto g1014;                                                                     //        GOTO 1014
                                                                                            //
     g1020: for (int iu = 1; iu<=1000; ++iu)                                                //1020    DO 1022 IU=1,1000
            {
                line = f1.ReadLine() ?? "";                                                 //        READ(1,1021) KTAB(IU),ATAB(IU)
                match = Regex.Match(line, "(-*\\d+)\\s*(.{0,5})");                          //1021    FORMAT(G,A5)
                Debug.WriteLine("read tokens");
                foreach (Group aGroup in match.Groups)
                {
                    Debug.Write(aGroup.Value);
                }
                Debug.WriteLine(".");
                KTAB[iu] = int.Parse(match.Groups[1].Value);
                ATAB[iu] = match.Groups[2].Value;
                if (KTAB[iu] == -1) goto g1002;                                             //        IF(KTAB(IU).EQ.-1)GOTO 1002
            }                                                                               //1022    CONTINUE
            Debug.WriteLine("Too many words");                                              //        PAUSE 'TOO MANY WORDS'
                                                                                            //
                                                                                            //
            // TRAVEL = negative if last this source + dest*1024 + keyword                  // TRAVEL = NEG IF LAST THIS SOURCE + DEST*1024 + KEYWORD
                                                                                            //
            // COND = 1 if light, 2 if don't ask question                                   //C COND  = 1 IF LIGHT,  2 IF DON T ASK QUESTION
                                                                                            //
                                                                                            //
                                                                                            //
                                                                                            //
                                                                                            //
     g1100: for (int i = 1; i<=100; ++i)                                                     //1100    DO 1101 I=1,100
            {
                IPLACE[i]=IPLT[i];                                                          //        IPLACE(I)=IPLT(I)
                IFIXED[i]=IFIXT[i];                                                         //        IFIXED(I)=IFIXT(I)
                ICHAIN[i] = 0;                                                              //1101    ICHAIN(I)=0
            }
                                                                                            //
            for (int i = 1; i<=300; ++i)                                                    //        DO 1102 I=1,300
            {
                COND[i]=0;                                                                  //        COND(I)=0
                ABB[i]=0;                                                                   //        ABB(I)=0
                IOBJ[i]=0;                                                                  //1102    IOBJ(I)=0
            }
            for (int i = 1; i <= 10; ++i)                                                   //        DO 1103 I=1,10
                COND[i] = 1;                                                                //1103    COND(I)=1
            COND[16] = 2;                                                                   //        COND(16)=2
            COND[20] = 2;                                                                   //        COND(20)=2
            COND[21] = 2;                                                                   //        COND(21)=2
            COND[22] = 2;                                                                   //        COND(22)=2
            COND[23] = 2;                                                                   //        COND(23)=2
            COND[24] = 2;                                                                   //        COND(24)=2
            COND[25] = 2;                                                                   //        COND(25)=2
            COND[26] = 2;                                                                   //        COND(26)=2
            COND[31] = 2;                                                                   //        COND(31)=2
            COND[32] = 2;                                                                   //        COND(32)=2
            COND[79] = 2;                                                                   //        COND(79)=2
                                                                                            //
            for (int i=1; i<=100; ++i)                                                      //        DO 1107 I=1,100
            {
                int KTEM = IPLACE[i];                                                       //        KTEM=IPLACE(I)
                if (KTEM == 0) goto g1107;                                                  //        IF(KTEM.EQ.0)GOTO 1107
                if (IOBJ[KTEM] != 0) goto g1104;                                            //        IF(IOBJ(KTEM).NE.0) GOTO 1104
                IOBJ[KTEM] = i;                                                             //        IOBJ(KTEM)=I
                goto g1107;                                                                 //        GO TO 1107
     g1104:     KTEM = IOBJ[KTEM];                                                          //1104    KTEM=IOBJ(KTEM)
     g1105:     if (ICHAIN[KTEM] != 0) goto g1106;                                          //1105    IF(ICHAIN(KTEM).NE.0) GOTO 1106
                ICHAIN[KTEM] = i;                                                           //        ICHAIN(KTEM)=I
                goto g1107;                                                                 //        GOTO 1107
     g1106:     KTEM = ICHAIN[KTEM];                                                        //1106    KTEM=ICHAIN(KTEM)
                goto g1105;                                                                 //        GOTO 1105
     g1107:;                                                                                //1107    CONTINUE
            }
     g1:    int IDWARF = 0;                                                                 //        IDWARF=0
            int IFIRST = 1;                                                                 //        IFIRST=1
            int IWEST = 0;                                                                  //        IWEST=0
            int ILONG = 1;                                                                  //        ILONG=1
            int IDETAL = 0;                                                                 //        IDETAL=0
            Debug.WriteLine("Init done");                                                   //        PAUSE 'INIT DONE'
                                                                                            //
                                                                                            //
                                                                                            //
            int YEA = 0; Yes(65, 1, 0, ref YEA);                                            //1       CALL YES(65,1,0,YEA)
            int L = 1;                                                                      //        L=1
            int LOC = 1;                                                                    //        LOC=1
     g2:    for (int i = 1; i<=3; ++i)                                                      //2       DO 73 I=1,3
            {
                if (ODLOC[i] != L || DSEEN[i] == 0) goto g73;                               //        IF(ODLOC(I).NE.L.OR.DSEEN(I).EQ.0)GOTO 73
                L = LOC;                                                                    //        L=LOC
                Speak(2);                                                                   //        CALL SPEAK(2)
                goto g74;                                                                   //        GOTO 74
     g73: ;                                                                                 //73      CONTINUE
            }
     g74:   LOC = L;                                                                        //74      LOC=L
                                                                                            //
            // Dwarf stuff                                                                  //C DWARF STUFF
                                                                                            //
            if (IDWARF != 0) goto g60;                                                      //        IF(IDWARF.NE.0) GOTO 60
            if (LOC == 15) IDWARF = 1;                                                      //        IF(LOC.EQ.15) IDWARF=1
            goto g71;                                                                       //        GOTO 71
     g60:   if (IDWARF != 1) goto g63;                                                      //60      IF(IDWARF.NE.1)GOTO 63
            if (RAN.NextDouble() > 0.05) goto g71;                                          //        IF(RAN(QZ).GT.0.05) GOTO 71
            IDWARF = 2;                                                                     //        IDWARF=2
            for (int i = 1; i <= 3; ++i)                                                    //        DO 61 I=1,3
            {
                DLOC[i] = 0;                                                                //        DLOC(I)=0
                ODLOC[i] = 0;                                                               //        ODLOC(I)=0
                DSEEN[i] = 0;                                                               //61      DSEEN(I)=0
            }
            Speak(3);                                                                       //        CALL SPEAK(3)
            ICHAIN[AXE] = IOBJ[LOC];                                                        //        ICHAIN(AXE)=IOBJ(LOC)
            IOBJ[LOC] = AXE;                                                                //        IOBJ(LOC)=AXE
            IPLACE[AXE] = LOC;                                                              //        IPLACE(AXE)=LOC
            goto g71;                                                                       //        GOTO 71
                                                                                            //
     g63:   IDWARF = IDWARF + 1;                                                            //63      IDWARF=IDWARF+1
            int ATTACK = 0;                                                                 //        ATTACK=0
            int DTOT = 0;                                                                   //        DTOT=0
            int STICK = 0;                                                                  //        STICK=0
            for (int i = 1; i <= 3; ++i)                                                    //        DO 66 I=1,3
            { 
                if (2 * i + IDWARF < 8) goto g66;                                           //        IF(2*I+IDWARF.LT.8)GOTO 66
                if (2 * i + IDWARF > 23 && DSEEN[i] == 0) goto g66;                         //        IF(2*I+IDWARF.GT.23.AND.DSEEN(I).EQ.0)GOTO 66
                ODLOC[i] = DLOC[i];                                                         //        ODLOC(I)=DLOC(I)
                if (DSEEN[i] != 0 && LOC > 14) goto g65;                                    //        IF(DSEEN(I).NE.0.AND.LOC.GT.14)GOTO 65
                DLOC[i] = DTRAV[i*2+IDWARF-8];                                              //        DLOC(I)=DTRAV(I*2+IDWARF-8)
                DSEEN[i] = 0;                                                               //        DSEEN(I)=0
                if (DLOC[i] != LOC && ODLOC[i] != LOC) goto g66;                            //        IF(DLOC(I).NE.LOC.AND.ODLOC(I).NE.LOC) GOTO 66
     g65:       DSEEN[i] = 1;                                                               //65      DSEEN(I)=1
                DLOC[i] = LOC;                                                              //        DLOC(I)=LOC
                DTOT = DTOT + 1;                                                            //        DTOT=DTOT+1
                if (ODLOC[i] != DLOC[i]) goto g66;                                          //        IF(ODLOC(I).NE.DLOC(I)) GOTO 66
                ATTACK = ATTACK + 1;                                                        //        ATTACK=ATTACK+1
                if (RAN.NextDouble() < 0.1) STICK = STICK + 1;                              //        IF(RAN(QZ).LT.0.1) STICK=STICK+1
     g66:;                                                                                  //66      CONTINUE
            }
            if (DTOT == 0) goto g71;                                                        //        IF(DTOT.EQ.0) GOTO 71
            if (DTOT == 1) goto g75;                                                        //        IF(DTOT.EQ.1)GOTO 75
            var stemp = " There are {0} threatening little dwarves in the room with you.";  //        TYPE 67,DTOT
            Console.WriteLine(String.Format(stemp, DTOT));                                  //67      FORMAT(' THERE ARE ',I2,' THREATENING LITTLE DWARVES IN THE
                                                                                            //        1  ROOM WITH YOU.',/)
            goto g77;                                                                       //        GOTO 77
     g75:   Speak(4);                                                                       //75      CALL SPEAK(4)
     g77:   if (ATTACK == 0) goto g71;                                                      //77      IF(ATTACK.EQ.0)GOTO 71
            if (ATTACK == 1) goto g79;                                                      //        IF(ATTACK.EQ.1)GOTO 79
            stemp = " {0} of them throw knives at you!";                                    //        TYPE 78,ATTACK
            Console.WriteLine(String.Format(stemp, ATTACK));                                //78      FORMAT(' ',I2,' OF THEM THROW KNIVES AT YOU!',/)
            goto g81;                                                                       //        GOTO 81
     g79:   Speak(5);                                                                       //79      CALL SPEAK(5)
            Speak(52 + STICK);                                                              //        CALL SPEAK(52+STICK)
            switch (STICK+1)                                                                //        GOTO(71,83)(STICK+1)
            {
                case 1: goto g71; break;
                case 2: goto g83; break;
            }
                                                                                            //
     g81:   if (STICK == 0) goto g69;                                                       //81      IF(STICK.EQ.0) GOTO 69
            if (STICK == 1) goto g82;                                                       //        IF(STICK.EQ.1)GOTO 82
            stemp = " {0} of them get you.";                                                //        TYPE 68,STICK
            Console.WriteLine(String.Format(stemp, STICK));                                 //68      FORMAT(' ',I2,' OF THEM GET YOU.',/)
            goto g83;                                                                       //        GOTO 83
     g82:   Speak(6);                                                                       //82      CALL SPEAK(6)
     g83:   Console.WriteLine("Game over");                                                 //83      PAUSE 'GAMES OVER'
            goto g71;                                                                       //        GOTO 71
     g69:   Speak(7);                                                                       //69      CALL SPEAK(7)
                                                                                            //
            // Place descriptor                                                             //C PLACE DESCRIPTOR
                                                                                            //
                                                                                            //
                                                                                            //
     g71:   KK=STEXT[L];                                                                    //71      KK=STEXT(L)
            if (ABB[L] == 0 || KK == 0) KK = LTEXT[L];                                      //        IF(ABB(L).EQ.0.OR.KK.EQ.0)KK=LTEXT(L)
            if (KK == 0) goto g7;                                                           //        IF(KK.EQ.0) GOTO 7
     g4:    for (int jj = 3; jj <= (int)LLINE[KK,2]; ++jj)                                  //4      TYPE 5,(LLINE(KK,JJ),JJ=3,LLINE(KK,2))
                Console.Write(LLINE[KK, jj]);                                               //5      FORMAT(20A5)
            Console.WriteLine();
            KK = KK + 1;                                                                    //        KK=KK+1
            if ((int)LLINE[KK-1, 1] != 0) goto g4;                                          //        IF(LLINE(KK-1,1).NE.0) GOTO 4
            Console.WriteLine();                                                            //        TYPE 6
                                                                                            //6      FORMAT(/)
     g7:    if (COND[L] == 2) goto g8;                                                      //7      IF(COND(L).EQ.2)GOTO 8
            if (LOC == 33 && RAN.NextDouble() < 0.25) Speak(8);                             //        IF(LOC.EQ.33.AND.RAN(QZ).LT.0.25)CALL SPEAK(8)
            J = L;                                                                          //        J=L
            goto g2000;                                                                     //        GOTO 2000
                                                                                            //
            // Go get a new location                                                        //C GO GET A NEW LOCATION
                                                                                            //
     g8:    KK = KEY[LOC];                                                                  //8       KK=KEY(LOC)
            if (KK == 0) goto g19;                                                          //        IF(KK.EQ.0)GOTO 19
            if (K == 57) goto g32;                                                          //        IF(K.EQ.57)GOTO 32
            if (K == 67) goto g40;                                                          //        IF(K.EQ.67)GOTO 40
            if (K == 8) goto g12;                                                           //        IF(K.EQ.8)GOTO 12
            LOLD = L;                                                                       //        LOLD=L
     g9:    int LL = TRAVEL[KK];                                                            //9       LL=TRAVEL(KK)
            if (LL < 0) LL = -LL;                                                           //        IF(LL.LT.0) LL=-LL
            if (1 == LL%1024) goto g10;                                                     //        IF(1.EQ.MOD(LL,1024))GOTO 10
            if (K == LL%1024) goto g10;                                                     //        IF(K.EQ.MOD(LL,1024))GOTO 10
            if (TRAVEL[KK] < 0) goto g11;                                                   //        IF(TRAVEL(KK).LT.0)GOTO 11
            KK = KK + 1;                                                                    //        KK=KK+1
            goto g9;                                                                        //        GOTO 9
     g12:   int TEMP = LOLD;                                                                //12      TEMP=LOLD
            LOLD = L;                                                                       //        LOLD=L
            L = TEMP;                                                                       //        L=TEMP
            goto g21;                                                                       //        GOTO 21
     g10:   L=LL/1024;                                                                      //10      L=LL/1024
            goto g21;                                                                       //        GOTO 21
     g11:   int JSPK = 12;                                                                  //11      JSPK=12
            if (K >= 43 && K <= 46) JSPK = 9;                                               //        IF(K.GE.43.AND.K.LE.46)JSPK=9
            if (K == 29 || K == 30) JSPK = 9;                                               //        IF(K.EQ.29.OR.K.EQ.30)JSPK=9
            if (K == 7 || K == 8 || K == 36 || K == 37 || K == 68)                          //        IF(K.EQ.7.OR.K.EQ.8.OR.K.EQ.36.OR.K.EQ.37.OR.K.EQ.68)
                JSPK = 10;                                                                  //        1 JSPK=10
            if (K == 1 || K == 19) JSPK = 11;                                               //        IF(K.EQ.11.OR.K.EQ.19)JSPK=11
            if (JVERB == 1) JSPK = 59;                                                      //        IF(JVERB.EQ.1)JSPK=59
            if (K == 48) JSPK = 42;                                                         //        IF(K.EQ.48)JSPK=42
            if (K == 17) JSPK = 80;                                                         //        IF(K.EQ.17)JSPK=80
            Speak(JSPK);                                                                    //        CALL SPEAK(JSPK)
            goto g2;                                                                        //        GOTO 2
     g19:   Speak(13);                                                                      //19      CALL SPEAK(13)
            L = LOC;                                                                        //        L=LOC
            if (IFIRST == 0) Speak(14);                                                     //        IF(IFIRST.EQ.0) CALL SPEAK(14)
     g21:   if (L < 300) goto g2;                                                           //21      IF(L.LT.300)GOTO 2
            int IL = L - 300 + 1;                                                           //        IL=L-300+1
            switch(IL)                                                                      //        GOTO(22,23,24,25,26,31,27,28,29,30,33,34,36,37)IL
            {
                case 1: goto g22; break;
                case 2: goto g23; break;
                case 3: goto g24; break;
                case 4: goto g25; break;
                case 5: goto g26; break;
                case 6: goto g31; break;
                case 7: goto g27; break;
                case 8: goto g28; break;
                case 9: goto g29; break;
                case 10: goto g30; break;
                case 11: goto g33; break;
                case 12: goto g34; break;
                case 13: goto g36; break;
                case 14: goto g37; break;
            }
            goto g2;                                                                        //        GOTO 2
                                                                                            //
     g22:   L = 6;                                                                          //22      L=6
            if (RAN.NextDouble() > 0.5) L = 5;                                              //        IF(RAN(QZ).GT.0.5) L=5
            goto g2;                                                                        //        GOTO 2
     g23:   L = 23;                                                                         //23      L=23
            if (PROP[GRATE] != 0) L = 9;                                                    //        IF(PROP(GRATE).NE.0) L=9
            goto g2;                                                                        //        GOTO 2
     g24:   L = 9;                                                                          //24      L=9
            if (PROP[GRATE] != 0) L = 8;                                                    //        IF(PROP(GRATE).NE.0)L=8
            goto g2;                                                                        //        GOTO 2
     g25:   L = 20;                                                                         //25      L=20
            if (IPLACE[NUGGET] != -1) L = 15;                                               //        IF(IPLACE(NUGGET).NE.-1)L=15
            goto g2;                                                                        //        GOTO 2
     g26:   L = 22;                                                                         //26      L=22
            if (IPLACE[NUGGET] != -1) L = 14;                                               //        IF(IPLACE(NUGGET).NE.-1) L=14
            goto g2;                                                                        //        GOTO 2
     g27:   L = 27;                                                                         //27      L=27
            if (PROP[12] == 0) L = 31;                                                      //        IF(PROP(12).EQ.0)L=31
            goto g2;                                                                        //        GOTO 2
     g28:   L = 28;                                                                         //28      L=28
            if (PROP[SNAKE] == 0) L = 32;                                                   //        IF(PROP(SNAKE).EQ.0)L=32
            goto g2;                                                                        //        GOTO 2
     g29:   L = 29;                                                                         //29      L=29
            if (PROP[SNAKE] == 0) L = 32;                                                   //        IF(PROP(SNAKE).EQ.0) L=32
            goto g2;                                                                        //        GOTO 2
     g30:   L = 30;                                                                         //30      L=30
            if (PROP[SNAKE] == 0) L = 32;                                                   //        IF(PROP(SNAKE).EQ.0) L=32
            goto g2;                                                                        //        GOTO 2
     g31:   Console.WriteLine("Game is over");                                              //31      PAUSE 'GAME IS OVER'
            goto g1100;                                                                     //        GOTO 1100
     g32:   if (IDETAL < 3) Speak(15);                                                      //32      IF(IDETAL.LT.3)CALL SPEAK(15)
            IDETAL = IDETAL + 1;                                                            //        IDETAL=IDETAL+1
            L = LOC;                                                                        //        L=LOC
            ABB[L] = 0;                                                                     //        ABB(L)=0
            goto g2;                                                                        //        GOTO 2
     g33:   L = 8;                                                                          //33      L=8
            if (PROP[GRATE] == 0) L = 9;                                                    //        IF(PROP(GRATE).EQ.0) L=9
            goto g2;                                                                        //        GOTO 2
     g34:   if (RAN.NextDouble() > 0.2) goto g35;                                           //34      IF(RAN(QZ).GT.0.2)GOTO 35
            L = 68;                                                                         //        L=68
            goto g2;                                                                        //        GOTO 2
     g35:   L = 65;                                                                         //35      L=65
     g38:   Speak(56);                                                                      //38      CALL SPEAK(56)
            goto g2;                                                                        //        GOTO 2
     g36:   if (RAN.NextDouble() > 0.2) goto g35;                                           //36      IF(RAN(QZ).GT.0.2)GOTO 35
            L = 39;                                                                         //        L=39
            if (RAN.NextDouble() > 0.5) L = 70;                                             //        IF(RAN(QZ).GT.0.5)L=70
            goto g2;                                                                        //        GOTO 2
     g37:   L = 66;                                                                         //37      L=66
            if (RAN.NextDouble() > 0.4) goto g38;                                           //        IF(RAN(QZ).GT.0.4)GOTO 38
            L = 71;                                                                         //        L=71
            if (RAN.NextDouble() > 0.25) L = 72;                                            //        IF(RAN(QZ).GT.0.25)L=72
            goto g2;                                                                        //        GOTO 2
     g39:   L = 66;                                                                         //39      L=66
            if (RAN.NextDouble() > 0.2) goto g38;                                           //        IF(RAN(QZ).GT.0.2)GOTO 38
            L = 77;                                                                         //        L=77
            goto g2;                                                                        //        GOTO 2
     g40:   if (LOC < 8) Speak(57);                                                         //40      IF(LOC.LT.8)CALL SPEAK(57)
            if (LOC >= 8) Speak(58);                                                        //        IF(LOC.GE.8)CALL SPEAK(58)
            L = LOC;                                                                        //        L=LOC
            goto g2;                                                                        //        GOTO 2
                                                                                            //
                                                                                            //
                                                                                            //
            // Do next input                                                                //C DO NEXT INPUT
                                                                                            //
                                                                                            //
     g2000: Debug.WriteLine("g2000");                                                       //2000    LTRUBL=0
                                                                                            //        LOC=J
                                                                                            //        ABB(J)=MOD((ABB(J)+1),5)
                                                                                            //        IDARK=0
                                                                                            //        IF(MOD(COND(J),2).EQ.1) GOTO 2003
                                                                                            //        IF((IPLACE(2).NE.J).AND.(IPLACE(2).NE.-1)) GOTO 2001
                                                                                            //        IF(PROP(2).EQ.1)GOTO 2003
                                                                                            //2001    CALL SPEAK(16)
                                                                                            //        IDARK=1
                                                                                            //
                                                                                            //
                                                                                            //2003    I=IOBJ(J)
                                                                                            //2004    IF(I.EQ.0) GOTO 2011
                                                                                            //        IF(((I.EQ.6).OR.(I.EQ.9)).AND.(IPLACE(10).EQ.-1))GOTO 2008
                                                                                            //        ILK=I
                                                                                            //        IF(PROP(I).NE.0) ILK=I+100
                                                                                            //        KK=BTEXT(ILK)
                                                                                            //        IF(KK.EQ.0) GOTO 2008
                                                                                            //2005    TYPE 2006,(LLINE(KK,JJ),JJ=3,LLINE(KK,2))
                                                                                            //2006    FORMAT(20A5)
                                                                                            //        KK=KK+1
                                                                                            //        IF(LLINE(KK-1,1).NE.0) GOTO 2005
                                                                                            //        TYPE 2007
                                                                                            //2007    FORMAT(/)
                                                                                            //2008    I=ICHAIN(I)
                                                                                            //        GOTO 2004
                                                                                            //
                                                                                            //
                                                                                            //
                                                                                            //C K=1 MEANS ANY INPUT
                                                                                            //
                                                                                            //
                                                                                            //2012    A=WD2
                                                                                            //        B=' '
                                                                                            //        TWOWDS=0
                                                                                            //        GOTO 2021
                                                                                            //
                                                                                            //2009    K=54
                                                                                            //2010    JSPK=K
                                                                                            //5200    CALL SPEAK(JSPK)
                                                                                            //
                                                                                            //2011    JVERB=0
                                                                                            //        JOBJ=0
                                                                                            //        TWOWDS=0
                                                                                            //
                                                                                            //2020    CALL GETIN(TWOWDS,A,WD2,B)
                                                                                            //        K=70
                                                                                            //        IF(A.EQ.'ENTER'.AND.(WD2.EQ.'STREA'.OR.WD2.EQ.'WATER'))GOTO 2010
                                                                                            //        IF(A.EQ.'ENTER'.AND.TWOWDS.NE.0)GOTO 2012
                                                                                            //2021    IF(A.NE.'WEST')GOTO 2023
                                                                                            //        IWEST=IWEST+1
                                                                                            //        IF(IWEST.NE.10)GOTO 2023
                                                                                            //        CALL SPEAK(17)
                                                                                            //2023    DO 2024 I=1,1000
                                                                                            //        IF(KTAB(I).EQ.-1)GOTO 3000
                                                                                            //        IF(ATAB(I).EQ.A)GOTO 2025
                                                                                            //2024    CONTINUE
                                                                                            //        PAUSE 'ERROR 6'
                                                                                            //2025    K=MOD(KTAB(I),1000)
                                                                                            //        KQ=KTAB(I)/1000+1
                                                                                            //        GOTO (5014,5000,2026,2010)KQ
                                                                                            //        PAUSE 'NO NO'
                                                                                            //2026    JVERB=K
                                                                                            //        JSPK=JSPKT(JVERB)
                                                                                            //        IF(TWOWDS.NE.0)GOTO 2028
                                                                                            //        IF(JOBJ.EQ.0)GOTO 2036
                                                                                            //2027    GOTO(9000,5066,3000,5031,2009,5031,9404,9406,5081,5200,
                                                                                            //        1 5200,5300,5506,5502,5504,5505)JVERB
                                                                                            //        PAUSE 'ERROR 5'
                                                                                            //
                                                                                            //
                                                                                            //2028    A=WD2
                                                                                            //        B=' '
                                                                                            //        TWOWDS=0
                                                                                            //        GOTO 2023
                                                                                            //
                                                                                            //3000    JSPK=60
                                                                                            //        IF(RAN(QZ).GT.0.8)JSPK=61
                                                                                            //        IF(RAN(QZ).GT.0.8)JSPK=13
                                                                                            //        CALL SPEAK(JSPK)
                                                                                            //        LTRUBL=LTRUBL+1
                                                                                            //        IF(LTRUBL.NE.3)GOTO 2020
                                                                                            //        IF(J.NE.13.OR.IPLACE(7).NE.13.OR.IPLACE(5).NE.-1)GOTO 2032
                                                                                            //        CALL YES(18,19,54,YEA)
                                                                                            //        GOTO 2033
                                                                                            //2032    IF(J.NE.19.OR.PROP(11).NE.0.OR.IPLACE(7).EQ.-1)GOTO 2034
                                                                                            //        CALL YES(20,21,54,YEA)
                                                                                            //        GOTO 2033
                                                                                            //2034    IF(J.NE.8.OR.PROP(GRATE).NE.0)GOTO 2035
                                                                                            //        CALL YES(62,63,54,YEA)
                                                                                            //2033    IF(YEA.EQ.0)GOTO 2011
                                                                                            //        GOTO 2020
                                                                                            //2035    IF(IPLACE(5).NE.J.AND.IPLACE(5).NE.-1)GOTO 2020
                                                                                            //        IF(JOBJ.NE.5)GOTO 2020
                                                                                            //        CALL SPEAK(22)
                                                                                            //        GOTO 2020
                                                                                            //
                                                                                            //
                                                                                            //2036    GOTO(2037,5062,5062,9403,2009,9403,9404,9406,5062,5062,
                                                                                            //        1 5200,5300,5062,5062,5062,5062)JVERB
                                                                                            //        PAUSE 'OOPS'
                                                                                            //2037    IF((IOBJ(J).EQ.0).OR.(ICHAIN(IOBJ(J)).NE.0)) GOTO 5062
                                                                                            //        DO 5312 I=1,3
                                                                                            //        IF(DSEEN(I).NE.0)GOTO 5062
                                                                                            //5312    CONTINUE
                                                                                            //        JOBJ=IOBJ(J)
                                                                                            //        GOTO 2027
                                                                                            //5062    IF(B.NE.' ')GOTO 5333
                                                                                            //        TYPE 5063,A
                                                                                            //5063    FORMAT('  ',A5,' WHAT?',/)
                                                                                            //        GOTO 2020
                                                                                            //
                                                                                            //5333    TYPE 5334,A,B
                                                                                            //5334    FORMAT(' ',2A5,' WHAT?',/)
                                                                                            //        GOTO 2020
                                                                                            //5014    IF(IDARK.EQ.0) GOTO 8
                                                                                            //
                                                                                            //        IF(RAN(QZ).GT.0.25) GOTO 8
                                                                                            //5017    CALL SPEAK(23)
                                                                                            //        PAUSE 'GAME IS OVER'
                                                                                            //        GOTO 2011
                                                                                            //
                                                                                            //
                                                                                            //
                                                                                            //5000    JOBJ=K
                                                                                            //        IF(TWOWDS.NE.0)GOTO 2028
                                                                                            //        IF((J.EQ.IPLACE(K)).OR.(IPLACE(K).EQ.-1)) GOTO 5004
                                                                                            //        IF(K.NE.GRATE)GOTO 502
                                                                                            //        IF((J.EQ.1).OR.(J.EQ.4).OR.(J.EQ.7))GOTO 5098
                                                                                            //        IF((J.GT.9).AND.(J.LT.15))GOTO 5097
                                                                                            //502     IF(B.NE.' ')GOTO 5316
                                                                                            //        TYPE 5005,A
                                                                                            //5005    FORMAT(' I SEE NO ',A5,' HERE.',/)
                                                                                            //        GOTO 2011
                                                                                            //5316    TYPE 5317,A,B
                                                                                            //5317    FORMAT(' I SEE NO ',2A5,' HERE.'/)
                                                                                            //        GOTO 2011
                                                                                            //5098    K=49
                                                                                            //        GOTO 5014
                                                                                            //5097    K=50
                                                                                            //        GOTO 5014
                                                                                            //5004    JOBJ=K
                                                                                            //        IF(JVERB.NE.0)GOTO 2027
                                                                                            //
                                                                                            //
                                                                                            //5064    IF(B.NE.' ')GOTO 5314
                                                                                            //        TYPE 5001,A
                                                                                            //5001    FORMAT(' WHAT DO YOU WANT TO DO WITH THE ',A5,'?',/)
                                                                                            //        GOTO 2020
                                                                                            //5314    TYPE 5315,A,B
                                                                                            //5315    FORMAT(' WHAT DO YOU WANT TO DO WITH THE ',2A5,'?',/)
                                                                                            //        GOTO 2020
                                                                                            //
                                                                                            //C CARRY
                                                                                            //
                                                                                            //9000    IF(JOBJ.EQ.18)GOTO 2009
                                                                                            //        IF(IPLACE(JOBJ).NE.J) GOTO 5200
                                                                                            //9001    IF(IFIXED(JOBJ).EQ.0)GOTO 9002
                                                                                            //        CALL SPEAK(25)
                                                                                            //        GOTO 2011
                                                                                            //9002    IF(JOBJ.NE.BIRD)GOTO 9004
                                                                                            //        IF(IPLACE(ROD).NE.-1)GOTO 9003
                                                                                            //        CALL SPEAK(26)
                                                                                            //        GOTO 2011
                                                                                            //9003    IF((IPLACE(4).EQ.-1).OR.(IPLACE(4).EQ.J)) GOTO 9004
                                                                                            //        CALL SPEAK(27)
                                                                                            //        GOTO 2011
                                                                                            //9004    IPLACE(JOBJ)=-1
                                                                                            //9005    IF(IOBJ(J).NE.JOBJ) GOTO 9006
                                                                                            //        IOBJ(J)=ICHAIN(JOBJ)
                                                                                            //        GOTO 2009
                                                                                            //9006    ITEMP=IOBJ(J)
                                                                                            //9007    IF(ICHAIN(ITEMP).EQ.(JOBJ)) GOTO 9008
                                                                                            //        ITEMP=ICHAIN(ITEMP)
                                                                                            //        GOTO 9007
                                                                                            //9008    ICHAIN(ITEMP)=ICHAIN(JOBJ)
                                                                                            //        GOTO 2009
                                                                                            //
                                                                                            //
                                                                                            //C LOCK, UNLOCK, NO OBJECT YET
                                                                                            //
                                                                                            //9403    IF((J.EQ.8).OR.(J.EQ.9))GOTO 5105
                                                                                            //5032    CALL SPEAK(28)
                                                                                            //        GOTO 2011
                                                                                            //5105    JOBJ=GRATE
                                                                                            //        GOTO 2027
                                                                                            //
                                                                                            //C DISCARD OBJECT
                                                                                            //
                                                                                            //5066    IF(JOBJ.EQ.18)GOTO 2009
                                                                                            //        IF(IPLACE(JOBJ).NE.-1) GOTO 5200
                                                                                            //5012    IF((JOBJ.NE.BIRD).OR.(J.NE.19).OR.(PROP(11).EQ.1))GOTO 9401
                                                                                            //        CALL SPEAK(30)
                                                                                            //        PROP(11)=1
                                                                                            //5160    ICHAIN(JOBJ)=IOBJ(J)
                                                                                            //        IOBJ(J)=JOBJ
                                                                                            //        IPLACE(JOBJ)=J
                                                                                            //        GOTO 2011
                                                                                            //
                                                                                            //9401    CALL SPEAK(54)
                                                                                            //        GOTO 5160
                                                                                            //
                                                                                            //C LOCK,UNLOCK OBJECT
                                                                                            //
                                                                                            //5031    IF(IPLACE(KEYS).NE.-1.AND.IPLACE(KEYS).NE.J)GOTO 5200
                                                                                            //        IF(JOBJ.NE.4)GOTO 5102
                                                                                            //        CALL SPEAK(32)
                                                                                            //        GOTO 2011
                                                                                            //5102    IF(JOBJ.NE.KEYS)GOTO 5104
                                                                                            //        CALL SPEAK(55)
                                                                                            //        GOTO 2011
                                                                                            //5104    IF(JOBJ.EQ.GRATE)GOTO 5107
                                                                                            //        CALL SPEAK(33)
                                                                                            //        GOTO 2011
                                                                                            //5107    IF(JVERB.EQ.4) GOTO 5033
                                                                                            //        IF(PROP(GRATE).NE.0)GOTO 5034
                                                                                            //        CALL SPEAK(34)
                                                                                            //        GOTO 2011
                                                                                            //5034    CALL SPEAK(35)
                                                                                            //        PROP(GRATE)=0
                                                                                            //        PROP(8)=0
                                                                                            //        GOTO 2011
                                                                                            //5033    IF(PROP(GRATE).EQ.0)GOTO 5109
                                                                                            //        CALL SPEAK(36)
                                                                                            //        GOTO 2011
                                                                                            //5109    CALL SPEAK(37)
                                                                                            //        PROP(GRATE)=1
                                                                                            //        PROP(8)=1
                                                                                            //        GOTO 2011
                                                                                            //
                                                                                            //
                                                                                            //
                                                                                            //C LIGHT LAMP
                                                                                            //
                                                                                            //9404    IF((IPLACE(2).NE.J).AND.(IPLACE(2).NE.-1))GOTO 5200
                                                                                            //        PROP(2)=1
                                                                                            //        IDARK=0
                                                                                            //        CALL SPEAK(39)
                                                                                            //        GOTO 2011
                                                                                            //
                                                                                            //C LAMP OFF
                                                                                            //
                                                                                            //9406    IF((IPLACE(2).NE.J).AND.(IPLACE(2).NE.-1)) GOTO 5200
                                                                                            //        PROP(2)=0
                                                                                            //        CALL SPEAK(40)
                                                                                            //        GOTO 2011
                                                                                            //
                                                                                            //C STRIKE
                                                                                            //
                                                                                            //5081    IF(JOBJ.NE.12)GOTO 5200
                                                                                            //        PROP(12)=1
                                                                                            //        GOTO 2003
                                                                                            //
                                                                                            //C ATTACK
                                                                                            //
                                                                                            //5300    DO 5313 ID=1,3
                                                                                            //        IID=ID
                                                                                            //        IF(DSEEN(ID).NE.0)GOTO 5307
                                                                                            //5313    CONTINUE
                                                                                            //        IF(JOBJ.EQ.0)GOTO 5062
                                                                                            //        IF(JOBJ.EQ.SNAKE) GOTO 5200
                                                                                            //        IF(JOBJ.EQ.BIRD) GOTO 5302
                                                                                            //        CALL SPEAK(44)
                                                                                            //        GOTO 2011
                                                                                            //5302    CALL SPEAK(45)
                                                                                            //        IPLACE(JOBJ)=300
                                                                                            //        GOTO 9005
                                                                                            //
                                                                                            //5307    IF(RAN(QZ).GT.0.4) GOTO 5309
                                                                                            //        DSEEN(IID)=0
                                                                                            //        ODLOC(IID)=0
                                                                                            //        DLOC(IID)=0
                                                                                            //        CALL SPEAK(47)
                                                                                            //        GOTO 5311
                                                                                            //5309    CALL SPEAK(48)
                                                                                            //5311    K=21
                                                                                            //        GOTO 5014
                                                                                            //
                                                                                            //C EAT
                                                                                            //
                                                                                            //5502    IF((IPLACE(FOOD).NE.J.AND.IPLACE(FOOD).NE.-1).OR.PROP(FOOD).NE.0
                                                                                            //        1 .OR.JOBJ.NE.FOOD)GOTO 5200
                                                                                            //        PROP(FOOD)=1
                                                                                            //5501    JSPK=72
                                                                                            //        GOTO 5200
                                                                                            //
                                                                                            //C DRINK
                                                                                            //
                                                                                            //5504    IF((IPLACE(WATER).NE.J.AND.IPLACE(WATER).NE.-1)
                                                                                            //        1 .OR.PROP(WATER).NE.0.OR.JOBJ.NE.WATER) GOTO 5200
                                                                                            //        PROP(WATER)=1
                                                                                            //        JSPK=74
                                                                                            //        GOTO 5200
                                                                                            //
                                                                                            //C RUB
                                                                                            //
                                                                                            //5505    IF(JOBJ.NE.LAMP)JSPK=76
                                                                                            //        GOTO 5200
                                                                                            //
                                                                                            //C POUR
                                                                                            //
                                                                                            //5506    IF(JOBJ.NE.WATER)JSPK=78
                                                                                            //        PROP(WATER)=1
                                                                                            //        GOTO 5200
                                                                                            //
                                                                                            //
                                                                                            //
                                                                                            //        END
            ;
        }
                                                                                            //
                                                                                            //
        public static void Speak(int IT)                                                    //        SUBROUTINE SPEAK(IT)
        {                                                                                   //        IMPLICIT INTEGER(A-Z)
                                                                                            //        COMMON RTEXT,LLINE
                                                                                            //        DIMENSION RTEXT(100),LLINE(1000,22)
                                                                                            //
            var KKT = RTEXT[IT];                                                            //        KKT=RTEXT(IT)
    s999:   if (KKT == 0) return;                                                           //        IF(KKT.EQ.0)RETURN
            for (int JJT = 3; JJT <= (int)LLINE[KKT, 2]; ++JJT)                             //999     TYPE 998, (LLINE(KKT,JJT),JJT=3,LLINE(KKT,2))
                Console.Write(LLINE[KKT,JJT]);                                              //998     FORMAT(20A5)
            Console.WriteLine();
            KKT = KKT + 1;                                                                  //        KKT=KKT+1
            if ((int)LLINE[KKT-1, 1] != 0) goto s999;                                       //        IF(LLINE(KKT-1,1).NE.0)GOTO 999
            Console.WriteLine();                                                            //997     TYPE 996
                                                                                            //996     FORMAT(/)
                                                                                            //        RETURN
         }                                                                                  //        END
                                                                                            //
                                                                                            //
        public static void GetIn(ref int TWOW, ref string B, ref string C, int D)                  //        SUBROUTINE GETIN(TWOW,B,C,D)
        {                                                                                   //        IMPLICIT INTEGER(A-Z)
            //I'm not porting this function                                                 //        DATA M2/"4000000000,"20000000,"100000,"400,"2,0/
            //The PDP10 used int36 as it's word, and could store 5 ASCII-7                  //6       ACCEPT 1,(A(I), I=1,4)
            //in each int.  This function gets two 5 characters words delimited by          //1       FORMAT(4A5)
            //a space.  Given the system dependence, I'm just reimplementing                
            TWOW = 0;                                                                       //        TWOW=0
            B = "";                                                                         //        S=0
            C = "";                                                                         //        B=A(1)
            var line = Console.ReadLine();                                                  //        DO 2 J=1,4
            var words = line.Split(null);                                                   //        DO 2 K=1,5
                                                                                            //        MASK1="774000000000
                                                                                            //        IF(K.NE.1) MASK1="177*M2(K)
            if (words.Length != 0)                                                          //        IF(S.EQ.0) GOTO 2
            {                                                                               //        TWOW=1
                B = words[0].Substring(0, Math.Min(5, words[0].Length))                     //        CALL SHIFT(A(J),7*(K-1),XX)
                    .ToUpper(CultureInfo.InvariantCulture);                                 //        CALL SHIFT(A(J+1),7*(K-6),YY)
                if (words.Length > 1)                                                       //        MASK=-M2(6-K)
                    {                                                                       //        C=(XX.AND.MASK)+(YY.AND.(-2-MASK))
                        C = words[1].Substring(0, Math.Min(5, words[0].Length))             //        GOTO 4
                        .ToUpper(CultureInfo.InvariantCulture);                             //3       IF(S.EQ.1) GOTO 2
                TWOW = 1;                                                                   //        S=1
                }                                                                           //        IF(J.EQ.1) B=(B.AND.-M2(K)).OR.("201004020100.AND.
            }                                                                               //        1 (-M2(K).XOR.-1))
                                                                                            //2       CONTINUE
                                                                                            //4       D=A(2)
                                                                                            //        RETURN
        }                                                                                   //        END
                                                                                            //
        public static void Yes(int X, int Y, int Z, ref int YEA)                                   //        SUBROUTINE YES(X,Y,Z,YEA)
        {                                                                                   //        IMPLICIT INTEGER(A-Z)
            string IA1 = "";
            string JUNK2 = "";
            int IB1 = 0, JUNK = 0;
            Speak(X);                                                                       //        CALL SPEAK(X)
            GetIn(ref JUNK, ref IA1, ref JUNK2, IB1);                                                //        CALL GETIN(JUNK,IA1,JUNK,IB1)
            if (IA1 == "NO" || IA1 == "N") goto y1;                                         //        IF(IA1.EQ.'NO'.OR.IA1.EQ.'N') GOTO 1
            YEA = 1;                                                                        //        YEA=1
            if (Y != 0) Speak(Y);                                                           //        IF(Y.NE.0) CALL SPEAK(Y)
            return;                                                                         //        RETURN
        y1: YEA = 0;                                                                        //1       YEA=0
            if(Z != 0) Speak(Z);                                                            //        IF(Z.NE.0)CALL SPEAK(Z)
            return;                                                                         //        RETURN
         }                                                                                  //        END
                                                                                            //
                                                                                            //
                                                                                            //
                                                                                            //        SUBROUTINE SHIFT (VAL,DIST,RES)
                                                                                            //        IMPLICIT INTEGER (A-Z)
                                                                                            //        RES=VAL
                                                                                            //        IF(DIST)10,20,30
                                                                                            //10      IDIST=-DIST
                                                                                            //        DO 11 I=1,IDIST
                                                                                            //        J = 0
                                                                                            //        IF (RES.LT.0) J="200000000000
                                                                                            //11      RES = ((RES.AND."377777777777)/2) + J
                                                                                            //20      RETURN
                                                                                            //30      DO 31 I=1,DIST
                                                                                            //        j = 0
                                                                                            //        IF ((RES.AND."200000000000).NE.0) J="400000000000
                                                                                            //31      RES = (RES.AND."177777777777)*2 + J
                                                                                            //        RETURN
                                                                                            //        END
                                                                                            //
    }
}
