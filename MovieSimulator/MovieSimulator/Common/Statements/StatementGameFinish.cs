using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSimulator.Common.Statements
{
    public class StatementGameFinish : StatementGame
    {
        public override void Execute()
        {
            GameSimulator.Instance.actionText.AppendText("La partie est terminée :)");
            MessageBox.Show("La partie est terminée :)");
        }
    }
}
