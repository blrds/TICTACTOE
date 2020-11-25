using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MachineTest(){
            LabCSH.Machine s = new LabCSH.Machine("a", 'b');
            Assert.AreEqual("a", s.Name);
            Assert.AreEqual('b', s.Symbol);
            Assert.AreEqual(LabCSH.PlayerType.Machine, s.type);
            LabCSH.Machine s1 = new LabCSH.Machine("a", 'b');
            Assert.IsTrue(s == s1);
            Assert.IsFalse(s != s1);
            Assert.IsTrue(s.Equals(s1));
            LabCSH.SmartMachine s2 = new LabCSH.SmartMachine("a", 'b');
            Assert.IsTrue(s == s2);
            Assert.IsFalse(s != s2);
            Assert.IsTrue(s.Equals(s2));
        }
        
        [TestMethod]
        public void SmartMachineTest() {
            LabCSH.SmartMachine s = new LabCSH.SmartMachine("a", 'b');
            Assert.AreEqual("a", s.Name);
            Assert.AreEqual('b', s.Symbol);
            Assert.AreEqual(LabCSH.PlayerType.SmartMachine, s.type);
            LabCSH.SmartMachine s1 = new LabCSH.SmartMachine("a", 'b');
            Assert.IsTrue(s==s1);
            Assert.IsFalse(s != s1);
            Assert.IsTrue(s.Equals(s1));
            LabCSH.Machine s2 = new LabCSH.Machine("a", 'b');
            Assert.IsTrue(s == s2);
            Assert.IsFalse(s != s2);
            Assert.IsTrue(s.Equals(s2));

        }

        [TestMethod]
        public void GameTest() {
            List<LabCSH.Player> p = new List<LabCSH.Player>() { };
            p.Add(new LabCSH.Machine("a", 'b'));
            p.Add(new LabCSH.SmartMachine("b", 'c'));
            LabCSH.Game g = new LabCSH.Game(p);
            Assert.AreEqual(p, g.Players);
            Assert.AreEqual(null, g.OrderedPlayer);
            
            Assert.AreEqual(3,g.Size);
            int check = 0;
            for (int i = 0; i < g.Size; i++)
                for (int j = 0; j < g.Size; j++)
                    if (g.Field[i][j] != g.DefSymbol) check++;
            Assert.IsTrue(check == 0);
            Assert.AreEqual(' ', g.DefSymbol);
            Assert.IsFalse(g.CheckWin('b'));
            g.Field[0][0] = 'b';
            g.Field[0][1] = 'b';
            g.Field[0][2] = 'b';
            Assert.IsTrue(g.CheckWin('b'));
            g.Field[0][1] = ' ';
            g.Field[0][2] = ' ';
            g.Field[1][0] = 'b';
            g.Field[2][0] = 'b';
            Assert.IsTrue(g.CheckWin('b'));
            g.Field[1][0] = ' ';
            g.Field[2][0] = ' ';
            g.Field[1][1] = 'b';
            g.Field[2][2] = 'b';
            Assert.IsTrue(g.CheckWin('b'));
            g.Field[0][0] = ' ';
            g.Field[2][2] = ' ';
            g.Field[0][2] = 'b';
            g.Field[2][0] = 'b';
            Assert.IsTrue(g.CheckWin('b'));
            g.Clear();
            Assert.IsFalse(g.CheckWin('b'));
        }
    }
}
