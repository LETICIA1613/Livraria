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
            TornarArrastavel(PbCapaadmin);
            TornarArrastavel(LblEditoraadmin);
            TornarArrastavel(LblPrecoadmin);
            TornarArrastavel(BtnCompraradmin);
            //
            TornarArrastavel(LblTxtDescricaoadmin);
            TornarArrastavel(TxtDescricaoadmin);
            //
            TornarArrastavel(LblInfor);
            TornarArrastavel(LblInfonomeadmin);
            TornarArrastavel(LblInfonomeadmin2);
            TornarArrastavel(LblInfoAutoradmin);
            TornarArrastavel(LblInfoAutoradmin2);
            TornarArrastavel(LblInfoNaciautoradmin);
            TornarArrastavel(LblNacionalidadeadmin);
            TornarArrastavel(LblInfoEditoraadmin);
            TornarArrastavel(LblInfoEditoraadmin2);
            TornarArrastavel(LblInfogenadmin);
            TornarArrastavel(LblGeneroadmin);
            TornarArrastavel(LblInfoFXadmin);
            TornarArrastavel(LblFXadmin);

            //
            TornarArrastavel(LblBiografiaadmin);
            TornarArrastavel(TxtBiografiaadmin);

            // Tornar redimensionáveis
            TornarRedimensionavel(LblTituloadmin);
            TornarRedimensionavel(TxtDescricaoadmin);
            TornarRedimensionavel(TxtBiografiaadmin);
            TornarRedimensionavel(PbCapaadmin);
        }

        private void BtnSalvarLayout_Click(object sender, EventArgs e)
        {
            try { 

                var layout = new LayoutHelper.LayoutInfo
                {

                    PosTitulo = LblTituloadmin.Location,
                    PosAutor = LblAutoradmin.Location,
                    PosImagem = PbCapaadmin.Location,
                    PosEditora = LblEditoraadmin.Location,
                    PosPreco = LblPrecoadmin.Location,
                    PosBtnComprar = BtnCompraradmin.Location,
                    //
                    PosDes = LblTxtDescricaoadmin.Location,
                    PosDescricao = TxtDescricaoadmin.Location,
                    //
                    PosInformacao = LblInfor.Location,
                    PosInforNome = LblInfonomeadmin.Location,
                    PosInforNomeRes = LblInfonomeadmin2.Location,
                    PosInforAutor = LblInfoAutoradmin.Location,
                    PosInforAutorRes = LblInfoAutoradmin2.Location,
                    PosInforNaci = LblInfoNaciautoradmin.Location,
                    PosInforNaciRes = LblNacionalidadeadmin.Location,
                    PosInforEdi = LblInfoEditoraadmin.Location,
                    PosInforEdiRes = LblInfoEditoraadmin2.Location,
                    PosInforFX = LblInfoFXadmin.Location,
                    PosFaixaEtaria = LblFXadmin.Location,
                    PosInforGen = LblInfogenadmin.Location,
                    PosGenero = LblGeneroadmin.Location,
                    //
                    PosBio = LblBiografiaadmin.Location,
                    PosBiografia = TxtBiografiaadmin.Location,
                    // 



                    TamTitulo = LblTituloadmin.Size,
                    TamAutor = LblAutoradmin.Size,
                    TamImagem = PbCapaadmin.Size,
                    TamEditora = LblEditoraadmin.Size,
                    TamPreco = LblPrecoadmin.Size,
                    TamBtnComprar = BtnCompraradmin.Size,
                    //
                    TamDes = LblTxtDescricaoadmin.Size,
                    TamDescricao = TxtDescricaoadmin.Size,
                    //
                    TamInformacao = LblInfor.Size,
                    TamInforNome = LblInfonomeadmin.Size,
                    TamInforNomeRes = LblInfonomeadmin2.Size,
                    TamInforAutor = LblInfoAutoradmin.Size,
                    TamInforAutorRes = LblInfoAutoradmin2.Size,
                    TamInforNaci = LblInfoNaciautoradmin.Size,
                    TamInforNaciRes = LblNacionalidadeadmin.Size,
                    TamInforEdi = LblInfoEditoraadmin.Size,
                    TamInforEdiRes = LblInfoEditoraadmin2.Size,
                    TamInforFX = LblInfoFXadmin.Size,
                    TamFaixaEtaria = LblFXadmin.Size,
                    TamInforGen = LblInfogenadmin.Size,
                    TamGenero = LblGeneroadmin.Size,
                    //
                    TamBio = LblBiografiaadmin.Size,
                    TamBiografia = TxtBiografiaadmin.Size

                };

                LayoutHelper.Salvar(layout);
                MessageBox.Show("Layout salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar layout: " + ex.Message);
            }
        }



        private void TornarArrastavel(Control controle)
        {
            bool arrastando = false;
            Point start = Point.Empty;

            controle.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    arrastando = true;
                    start = e.Location;
                    controle.BringToFront();
                }
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

        private void TornarRedimensionavel(Control controle)
        {
            const int margin = 5;
            bool redimensionando = false;
            Point start = Point.Empty;
            Size startSize = Size.Empty;

            controle.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left &&
                    e.X >= controle.Width - margin &&
                    e.Y >= controle.Height - margin)
                {
                    redimensionando = true;
                    start = e.Location;
                    startSize = controle.Size;
                    controle.Cursor = Cursors.SizeNWSE;
                }
            };

            controle.MouseMove += (s, e) =>
            {
                if (e.X >= controle.Width - margin && e.Y >= controle.Height - margin)
                {
                    controle.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    controle.Cursor = Cursors.Default;
                }

                if (redimensionando)
                {
                    int newWidth = Math.Max(50, startSize.Width + (e.X - start.X));
                    int newHeight = Math.Max(20, startSize.Height + (e.Y - start.Y));
                    controle.Size = new Size(newWidth, newHeight);
                }
            };

            controle.MouseUp += (s, e) =>
            {
                redimensionando = false;
                controle.Cursor = Cursors.Default;
            };
        }

        private void LblGeneroadmin_Click(object sender, EventArgs e)
        {

        }

        private void LblTxtDescricao_Click(object sender, EventArgs e)
        {

        }

        private void LblInfonomeadmin2_Click(object sender, EventArgs e)
        {

        }

    }
}


    

