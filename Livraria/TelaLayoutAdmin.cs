using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria
{
    public partial class TelaLayoutAdmin : Form
    {
        public TelaLayoutAdmin()
        {
            InitializeComponent();
            TornarArrastavel(LblTituloadmin);
            TornarArrastavel(LblAutoradmin);
            TornarArrastavel(LblDescricaoadmin);
            TornarArrastavel(PbCapaadmin);
        }

        private void BtnSalvarLayout_Click(object sender, EventArgs e)
        {
            var layout = new LayoutHelper.LayoutInfo
            {

                PosTitulo = LblTituloadmin.Location,
                PosAutor = LblAutoradmin.Location,
                PosDescricao = LblDescricaoadmin.Location,
                PosImagem = PbCapaadmin.Location,

                TamTitulo = LblTituloadmin.Size,
                TamAutor = LblAutoradmin.Size,
                TamDescricao = LblDescricaoadmin.Size,
                TamImagem = PbCapaadmin.Size
            };
            LayoutHelper.Salvar(layout);
            MessageBox.Show("Layout salvo com sucesso!");
        }
        private void TornarArrastavel(Control controle)
        {
            bool arrastando = false;
            Point start = Point.Empty;

            controle.MouseDown += (s, e) =>
            {
                arrastando = true;
                start = new Point(e.X, e.Y);
            };

            controle.MouseMove += (s, e) =>
            {
                if (arrastando)
                {
                    controle.Left += e.X - start.X;
                    controle.Top += e.Y - start.Y;
                }
            };

            controle.MouseUp += (s, e) =>
            {
                arrastando = false;
            };
        }
    }
}


    

