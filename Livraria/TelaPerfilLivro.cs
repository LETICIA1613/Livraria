using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Livraria
{
    public partial class TelaPerfilLivro: Form
    {
        private int id;

        public TelaPerfilLivro(int id)
        {
            this.id = id;
            InitializeComponent();
            this.BackColor = Color.White;

        }
        private void TelaPerfilLivro_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;

            ConfigurarControles();
            CarregarInformacoesDoLivro();
            AplicarLayout();
            AjustarAlturaTextBoxAuto();
            CarregarLivrosSemelhantes();
            AtualizarScrollDoForm();


        }
        private void ConfigurarControles()
        { // Configurar todas as labels para não serem AutoSize
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.AutoSize = false;
                }
            }

            // TextBox - descrição
            TxtDescricao.Multiline = true;
            TxtDescricao.ReadOnly = true;
            TxtDescricao.WordWrap = true;
            TxtDescricao.BorderStyle = BorderStyle.None;
            TxtDescricao.BackColor = Color.White;
            TxtDescricao.ForeColor = Color.Black;
            TxtDescricao.Font = new Font("Arial", 10);
            TxtDescricao.ScrollBars = ScrollBars.None;

            // TextBox - biografia
            TxtBiografia.Multiline = true;
            TxtBiografia.ReadOnly = true;
            TxtBiografia.WordWrap = true;
            TxtBiografia.BorderStyle = BorderStyle.None;
            TxtBiografia.BackColor = Color.White;
            TxtBiografia.ForeColor = Color.Black;
            TxtBiografia.Font = new Font("Arial", 10);
            TxtBiografia.ScrollBars = ScrollBars.None;

            // PictureBox
            PbCapa2.SizeMode = PictureBoxSizeMode.Zoom;

            // Configurar cores e fontes específicas
            LblTitulo2.Font = new Font("Arial", 16, FontStyle.Bold);
            LblTitulo2.ForeColor = Color.DarkBlue;

            LblPreco2.Font = new Font("Arial", 14, FontStyle.Bold);
            LblPreco2.ForeColor = Color.Green;

            // Habilita scroll na página
            this.AutoScroll = true;
        }
        
        private void CarregarInformacoesDoLivro()
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
                    SELECT 
                        L.Nome AS Titulo,
                        L.Preco,
                        L.Foto,
                        L.Descricao,
                        E.Nome AS Editora,
                        F.Idades AS FaixaEtaria,
                        STUFF(
                            (SELECT ', ' + G2.Nome
                             FROM LivroGeneros LG2
                             INNER JOIN Generos G2 ON LG2.GeneroId = G2.Id
                             WHERE LG2.LivroId = L.Id
                             FOR XML PATH('')), 1, 2, '') AS Generos,
                        STUFF(
                            (SELECT ', ' + A2.Nome
                             FROM LivroAutores LA2
                             INNER JOIN Autores A2 ON LA2.AutorId = A2.Id
                             WHERE LA2.LivroId = L.Id
                             FOR XML PATH('')), 1, 2, '') AS Autores,
                        STUFF(
                            (SELECT DISTINCT ', ' + A2.Nacionalidade
                             FROM LivroAutores LA2
                             INNER JOIN Autores A2 ON LA2.AutorId = A2.Id
                             WHERE LA2.LivroId = L.Id
                             FOR XML PATH('')), 1, 2, '') AS Nacionalidades,
                        STUFF(
                            (SELECT CHAR(10) + '• ' + A2.Nome + ': ' + A2.Biografia
                             FROM LivroAutores LA2
                             INNER JOIN Autores A2 ON LA2.AutorId = A2.Id
                             WHERE LA2.LivroId = L.Id
                             FOR XML PATH('')), 1, 2, '') AS Biografias
                    FROM Livros L
                    LEFT JOIN Editora E ON L.EditoraId = E.Id
                    LEFT JOIN FaixaEtaria F ON L.FaixaEtariaId = F.Id
                    WHERE L.Id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                // DADOS PRINCIPAIS (lado da imagem)
                                LblTitulo2.Text = reader["Titulo"]?.ToString() ?? "Título não disponível";
                                LblAutor2.Text = reader["Autores"]?.ToString() ?? "Autores não disponíveis";
                                LblEditora2.Text = reader["Editora"]?.ToString() ?? "Editora não disponível";

                                // Preço formatado
                                if (reader["Preco"] != DBNull.Value && decimal.TryParse(reader["Preco"].ToString(), out decimal preco))
                                {
                                    LblPreco2.Text = $"R$ {preco:F2}";
                                }
                                else
                                {
                                    LblPreco2.Text = "Preço não disponível";
                                }

                                // DESCRIÇÃO
                                TxtDescricao.Text = reader["Descricao"]?.ToString() ?? "Descrição não disponível";

                                // INFORMAÇÕES DETALHADAS
                                LblInfoNome2.Text = reader["Titulo"]?.ToString() ?? "Título não disponível";
                                LblInfoAutor2.Text = reader["Autores"]?.ToString() ?? "Autores não disponíveis";
                                LblNacionalidade.Text = reader["Nacionalidades"]?.ToString() ?? "Nacionalidades não disponíveis";
                                LblInfoEditora2.Text = reader["Editora"]?.ToString() ?? "Editora não disponível";
                                LblGenero2.Text = reader["Generos"]?.ToString() ?? "Gêneros não disponíveis";
                                LblFaixa2.Text = reader["FaixaEtaria"]?.ToString() ?? "Faixa etária não disponível";

                                // BIOGRAFIA
                                string biografias = reader["Biografias"]?.ToString() ?? "Biografias não disponíveis";
                                TxtBiografia.Text = biografias.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&#x0D;", "\r");
                                AjustarLabelsDinamicas();
                                // IMAGEM
                                if (reader["Foto"] != DBNull.Value)
                                {
                                    try
                                    {
                                        byte[] imgBytes = (byte[])reader["Foto"];
                                        using (MemoryStream ms = new MemoryStream(imgBytes))
                                        {
                                            PbCapa2.Image = Image.FromStream(ms);
                                        }
                                    }
                                    catch (Exception imgEx)
                                    {
                                        PbCapa2.Image = null;
                                        Console.WriteLine("Erro ao carregar imagem: " + imgEx.Message);
                                    }
                                }
                                else
                                {
                                    PbCapa2.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Livro não encontrado!");
                            }
                        }
                    }
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações: " + ex.Message);
            }
        }

        private void AjustarLabelsDinamicas()
        {
            // labels que recebem conteúdo variável do DB
            var dinamicas = new Label[] { LblInfoNome2, LblInfoAutor2, LblNacionalidade, LblInfoEditora2, LblGenero2 };

            foreach (var lbl in dinamicas)
            {
                lbl.AutoSize = true;                     // permite ajustar altura automaticamente
                lbl.MaximumSize = new Size(400, 0);      // largura máxima (ajuste 400 se quiser)
                lbl.AutoEllipsis = false;                // evita "..." se estiver aparecendo
            }

            // Reposicione controles abaixo se necessário (ex.: LblBiografia e TxtBiografia)
            int proximoY = LblGenero2.Bottom + 20;
            LblBiografia.Location = new Point(LblBiografia.Location.X, proximoY);
            TxtBiografia.Location = new Point(TxtBiografia.Location.X, proximoY + 30);

            // Ajusta textboxes e scroll
            AjustarAlturaTextBoxAuto();
            AtualizarScrollDoForm();
        }



        private void AjustarAlturaTextBoxAuto()
        {
            try
            {
                // Ajustar altura da DESCRIÇÃO para todo o conteúdo
                if (!string.IsNullOrEmpty(TxtDescricao.Text))
                {
                    int padding = 25;
                    Size proposedSize = new Size(TxtDescricao.Width, int.MaxValue);
                    Size textSize = TextRenderer.MeasureText(TxtDescricao.Text, TxtDescricao.Font, proposedSize, TextFormatFlags.WordBreak);
                    TxtDescricao.Height = textSize.Height + padding;
                }

                // Ajustar altura da BIOGRAFIA para todo o conteúdo
                if (!string.IsNullOrEmpty(TxtBiografia.Text))
                {
                    int padding = 25;
                    Size proposedSize = new Size(TxtBiografia.Width, int.MaxValue);
                    Size textSize = TextRenderer.MeasureText(TxtBiografia.Text, TxtBiografia.Font, proposedSize, TextFormatFlags.WordBreak);
                    TxtBiografia.Height = textSize.Height + padding;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar altura: {ex.Message}");
            }
        }

        private void AtualizarScrollDoForm()
        {
            try
            {
                int maiorBottom = 0;

                // Encontrar o controle mais abaixo na página
                foreach (Control controle in this.Controls)
                {
                    if (controle.Visible && controle.Bottom > maiorBottom)
                    {
                        maiorBottom = controle.Bottom;
                    }
                }

                // Definir tamanho mínimo para scroll
                this.AutoScrollMinSize = new Size(0, maiorBottom + 100);
                this.PerformLayout();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao atualizar scroll: {ex.Message}");
                this.AutoScrollMinSize = new Size(0, 1200);
            }
        }


        private void AplicarLayout()
        {
            try
            {
                var layout = LayoutHelper.Carregar();

                // APLICAR TODAS AS POSIÇÕES COM OS NOMES CORRETOS
                PbCapa2.Location = layout.PosImagem;

                // Informações principais (lado da capa)
                LblTitulo2.Location = layout.PosTitulo;
                LblAutor2.Location = layout.PosAutor;
                LblEditora2.Location = layout.PosEditora;
                LblPreco2.Location = layout.PosPreco;

                // Descrição
                LblTxtDescricao.Location = layout.PosDes;
                TxtDescricao.Location = layout.PosDescricao;

                // Informações detalhadas
                LblInfor.Location = layout.PosInformacao;
                LblInfoNome.Location = layout.PosInforNome;
                LblInfoNome2.Location = layout.PosInforNomeRes;
                LblInfoAutor.Location = layout.PosInforAutor;
                LblInfoAutor2.Location = layout.PosInforAutorRes;
                LblInfoNaciAutor.Location = layout.PosInforNaci;
                LblNacionalidade.Location = layout.PosInforNaciRes;
                LblInfoEditora.Location = layout.PosInforEdi;
                LblInfoEditora2.Location = layout.PosInforEdiRes;
                LblInfoFX.Location = layout.PosInforFX;
                LblFaixa2.Location = layout.PosFaixaEtaria;
                LblInfoGenero.Location = layout.PosInforGen;
                LblGenero2.Location = layout.PosGenero;

                // Biografia
                LblBiografia.Location = layout.PosBio;
                TxtBiografia.Location = layout.PosBiografia;

                // APLICAR TODOS OS TAMANHOS
                PbCapa2.Size = layout.TamImagem;
                LblTitulo2.Size = layout.TamTitulo;
                LblAutor2.Size = layout.TamAutor;
                LblEditora2.Size = layout.TamEditora;
                LblPreco2.Size = layout.TamPreco;
                LblTxtDescricao.Size = layout.TamDes;
                TxtDescricao.Size = layout.TamDescricao;
                LblInfor.Size = layout.TamInformacao;
                LblInfoNome.Size = layout.TamInforNome;
                LblInfoNome2.Size = layout.TamInforNomeRes;
                LblInfoAutor.Size = layout.TamInforAutor;
                LblInfoAutor2.Size = layout.TamInforAutorRes;
                LblInfoNaciAutor.Size = layout.TamInforNaci;
                LblNacionalidade.Size = layout.TamInforNaciRes;
                LblInfoEditora.Size = layout.TamInforEdi;
                LblInfoEditora2.Size = layout.TamInforEdiRes;
                LblInfoFX.Size = layout.TamInforFX;
                LblFaixa2.Size = layout.TamFaixaEtaria;
                LblInfoGenero.Size = layout.TamInforGen;
                LblGenero2.Size = layout.TamGenero;
                LblBiografia.Size = layout.TamBio;
                TxtBiografia.Size = layout.TamBiografia;

                this.AutoScroll = true;

                // Debug para verificar se está aplicando corretamente
                Console.WriteLine("Layout aplicado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao aplicar layout: " + ex.Message);

                // Se der erro, aplica layout fixo
                AplicarLayoutFixo();
            }
        }
        private void AplicarLayoutFixo()
        {
            try
            {
                // LAYOUT FIXO QUE FUNCIONA - baseado na estrutura que você mostrou
                int x = 30, y = 30;

                // Capa
                PbCapa2.Location = new Point(x, y);
                PbCapa2.Size = new Size(150, 220);

                // Informações principais (lado direito da capa)
                LblTitulo2.Location = new Point(200, y);
                LblTitulo2.Size = new Size(400, 35);
                LblTitulo2.Font = new Font("Arial", 16, FontStyle.Bold);

                LblAutor2.Location = new Point(200, y + 40);
                LblAutor2.Size = new Size(400, 25);

                LblEditora2.Location = new Point(200, y + 70);
                LblEditora2.Size = new Size(400, 25);

                LblPreco2.Location = new Point(200, y + 100);
                LblPreco2.Size = new Size(200, 30);
                LblPreco2.Font = new Font("Arial", 14, FontStyle.Bold);

                // Descrição
                LblTxtDescricao.Location = new Point(x, y + 260);
                LblTxtDescricao.Size = new Size(200, 25);
                LblTxtDescricao.Text = "Descrição do Livro";
                LblTxtDescricao.Font = new Font("Arial", 12, FontStyle.Bold);

                TxtDescricao.Location = new Point(x, y + 290);
                TxtDescricao.Size = new Size(600, 120);

                // Informações do Livro
                LblInfor.Location = new Point(x, y + 430);
                LblInfor.Size = new Size(200, 25);
                LblInfor.Text = "Informações do Livro";
                LblInfor.Font = new Font("Arial", 12, FontStyle.Bold);

                // Nome
                LblInfoNome.Location = new Point(x, y + 460);
                LblInfoNome.Size = new Size(80, 25);
                LblInfoNome.Text = "Nome:";

                LblInfoNome2.Location = new Point(x + 90, y + 460);
                LblInfoNome2.Size = new Size(400, 25);

                // Autor
                LblInfoAutor.Location = new Point(x, y + 490);
                LblInfoAutor.Size = new Size(80, 25);
                LblInfoAutor.Text = "Autor:";

                LblInfoAutor2.Location = new Point(x + 90, y + 490);
                LblInfoAutor2.Size = new Size(400, 25);

                // Nacionalidade
                LblInfoNaciAutor.Location = new Point(x, y + 520);
                LblInfoNaciAutor.Size = new Size(150, 25);
                LblInfoNaciAutor.Text = "Nacionalidade:";

                LblNacionalidade.Location = new Point(x + 160, y + 520);
                LblNacionalidade.Size = new Size(400, 25);

                // Editora
                LblInfoEditora.Location = new Point(x, y + 550);
                LblInfoEditora.Size = new Size(80, 25);
                LblInfoEditora.Text = "Editora:";

                LblInfoEditora2.Location = new Point(x + 90, y + 550);
                LblInfoEditora2.Size = new Size(400, 25);

                // Faixa Etária
                LblInfoFX.Location = new Point(x, y + 580);
                LblInfoFX.Size = new Size(100, 25);
                LblInfoFX.Text = "Faixa Etária:";

                LblFaixa2.Location = new Point(x + 110, y + 580);
                LblFaixa2.Size = new Size(400, 25);

                // Gênero
                LblInfoGenero.Location = new Point(x, y + 610);
                LblInfoGenero.Size = new Size(80, 25);
                LblInfoGenero.Text = "Gênero:";

                LblGenero2.Location = new Point(x + 90, y + 610);
                LblGenero2.Size = new Size(400, 25);

                // Biografia
                LblBiografia.Location = new Point(x, y + 650);
                LblBiografia.Size = new Size(200, 25);
                LblBiografia.Text = "Biografia do Autor";
                LblBiografia.Font = new Font("Arial", 12, FontStyle.Bold);

                TxtBiografia.Location = new Point(x, y + 680);
                TxtBiografia.Size = new Size(600, 150);

                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(0, 900);

                Console.WriteLine("Layout fixo aplicado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no layout fixo: " + ex.Message);
            }
        }
        private int paginaAtual = 0;
        private List<Panel> todosLivros = new List<Panel>();
        private Button btnProximo;
        private Button btnAnterior;

        private void CarregarLivrosSemelhantes()
        {
            try
            {
                using (SqlConnection con = Conexao.GetConnection())
                {
                    con.Open();
                    string query = @"
            SELECT TOP 12 
                L.Id,
                L.Nome AS Titulo,
                L.Preco,
                L.Foto,
                A.Nome AS Autor
            FROM Livros L
            INNER JOIN LivroGeneros LG ON L.Id = LG.LivroId
            INNER JOIN LivroGeneros LG2 ON LG.GeneroId = LG2.GeneroId
            INNER JOIN LivroAutores LA ON L.Id = LA.LivroId
            INNER JOIN Autores A ON LA.AutorId = A.Id
            WHERE LG2.LivroId = @id 
            AND L.Id != @id
            GROUP BY L.Id, L.Nome, L.Preco, L.Foto, A.Nome
            ORDER BY COUNT(LG.GeneroId) DESC, L.Nome";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Adicionar título da seção
                            AdicionarTituloSecao();

                            int y = TxtBiografia.Bottom + 80;

                           // Criar container para os livros (MAIOR)
                            Panel containerLivros = new Panel();
                            containerLivros.Location = new Point(30, y);
                            containerLivros.Size = new Size(700, 230); // Aumentei a altura
                            containerLivros.BackColor = Color.White;
                            this.Controls.Add(containerLivros);

                            // Ler todos os livros e criar os panels
                            while (reader.Read())
                            {
                                Panel livroPanel = CriarLivroPanel(reader);
                                todosLivros.Add(livroPanel);
                                containerLivros.Controls.Add(livroPanel);
                            }

                            // Só mostra controles se tiver mais de 4 livros
                            if (todosLivros.Count > 4)
                            {
                                AdicionarBotoesNavegacao(containerLivros);
                            }

                            // Mostrar primeira página
                            MostrarPagina(0);

                            if (todosLivros.Count == 0)
                            {
                                AdicionarMensagemSemLivros(y);
                            }
                        }
                    }
                }

                AtualizarScrollDoForm();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar livros semelhantes: {ex.Message}");
            }
        }
        private void AbrirPerfilLivro(int livroId)
        {
            TelaPerfilLivro perfil = new TelaPerfilLivro(livroId);
            perfil.Show();
            this.Close();
        }

        private Panel CriarLivroPanel(SqlDataReader reader)
        {
            Panel panelLivro = new Panel();
            panelLivro.Size = new Size(160, 220); // Aumentei a altura
            panelLivro.BackColor = Color.White;
            panelLivro.Cursor = Cursors.Hand;
            panelLivro.Visible = false;

            // PictureBox para a capa (MAIOR - sem fundo cinza)
            PictureBox pbCapa = new PictureBox();
            pbCapa.Location = new Point(5, 0); // Centralizado
            pbCapa.Size = new Size(150, 140); // MUITO maior
            pbCapa.SizeMode = PictureBoxSizeMode.Zoom;
            pbCapa.BackColor = Color.White; // Fundo branco ao invés de cinza
            pbCapa.BorderStyle = BorderStyle.None; // Sem borda

            // Carregar imagem
            if (reader["Foto"] != DBNull.Value)
            {
                try
                {
                    byte[] imgBytes = (byte[])reader["Foto"];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        pbCapa.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    pbCapa.Image = null;
                }
            }

            // Nome do Autor (MAIOR e mais destacado)
            Label lblAutor = new Label();
            lblAutor.Location = new Point(5, 145);
            lblAutor.Size = new Size(150, 18);
            lblAutor.Text = reader["Autor"]?.ToString() ?? "Autor";
            lblAutor.Font = new Font("Arial", 9, FontStyle.Bold); // Negrito
            lblAutor.ForeColor = Color.DarkGray;
            lblAutor.TextAlign = ContentAlignment.MiddleLeft;

            // Título do Livro (MAIOR)
            Label lblTitulo = new Label();
            lblTitulo.Location = new Point(5, 165);
            lblTitulo.Size = new Size(150, 35);
            lblTitulo.Text = reader["Titulo"]?.ToString() ?? "Título";
            lblTitulo.Font = new Font("Arial", 10, FontStyle.Bold); // Maior e negrito
            lblTitulo.ForeColor = Color.Black;

            // Preço (MAIOR e mais destacado)
            Label lblPreco = new Label();
            lblPreco.Location = new Point(5, 200);
            lblPreco.Size = new Size(150, 18);
            if (reader["Preco"] != DBNull.Value && decimal.TryParse(reader["Preco"].ToString(), out decimal preco))
            {
                lblPreco.Text = $"R$ {preco:F2}";
            }
            else
            {
                lblPreco.Text = "R$ --";
            }
            lblPreco.Font = new Font("Arial", 11, FontStyle.Bold); // Maior
            lblPreco.ForeColor = Color.Green;

            // Adicionar controles ao panel
            panelLivro.Controls.Add(pbCapa);
            panelLivro.Controls.Add(lblAutor);
            panelLivro.Controls.Add(lblTitulo);
            panelLivro.Controls.Add(lblPreco);

            // Evento de clique
            int livroId = Convert.ToInt32(reader["Id"]);
            panelLivro.Click += (sender, e) => AbrirPerfilLivro(livroId);

            // Fazer todos os controles internos clicáveis também
            foreach (Control control in panelLivro.Controls)
            {
                control.Cursor = Cursors.Hand;
                control.Click += (sender, e) => AbrirPerfilLivro(livroId);
            }

            return panelLivro;
        }

        private void AdicionarBotoesNavegacao(Panel container)
        {
            // Botão Anterior (seta esquerda)
            btnAnterior = new Button();
            btnAnterior.Location = new Point(container.Left - 40, container.Top + 70);
            btnAnterior.Size = new Size(30, 30);
            btnAnterior.Text = "‹";
            btnAnterior.Font = new Font("Arial", 16, FontStyle.Bold);
            btnAnterior.BackColor = Color.White;
            btnAnterior.ForeColor = Color.DarkBlue;
            btnAnterior.FlatStyle = FlatStyle.Flat;
            btnAnterior.Cursor = Cursors.Hand;
            btnAnterior.Click += (sender, e) => MostrarPagina(paginaAtual - 1);
            this.Controls.Add(btnAnterior);
            btnAnterior.BringToFront();

            // Botão Próximo (seta direita)
            btnProximo = new Button();
            btnProximo.Location = new Point(container.Right + 10, container.Top + 70);
            btnProximo.Size = new Size(30, 30);
            btnProximo.Text = "›";
            btnProximo.Font = new Font("Arial", 16, FontStyle.Bold);
            btnProximo.BackColor = Color.White;
            btnProximo.ForeColor = Color.DarkBlue;
            btnProximo.FlatStyle = FlatStyle.Flat;
            btnProximo.Cursor = Cursors.Hand;
            btnProximo.Click += (sender, e) => MostrarPagina(paginaAtual + 1);
            this.Controls.Add(btnProximo);
            btnProximo.BringToFront();

            // Inicialmente esconder botão anterior
            btnAnterior.Visible = false;
        }

        private void MostrarPagina(int pagina)
        {
            // Validar página
            int totalPaginas = (int)Math.Ceiling(todosLivros.Count / 4.0);
            if (pagina < 0 || pagina >= totalPaginas) return;

            paginaAtual = pagina;

            // Esconder todos os livros
            foreach (var livro in todosLivros)
            {
                livro.Visible = false;
            }

            // Mostrar apenas 4 livros da página atual
            int inicio = pagina * 4;
            int fim = Math.Min(inicio + 4, todosLivros.Count);

            for (int i = inicio; i < fim; i++)
            {
                todosLivros[i].Visible = true;
                todosLivros[i].Location = new Point((i - inicio) * 170, 0); // Aumentei o espaçamento
            }

            // Atualizar visibilidade dos botões
            if (btnAnterior != null && btnProximo != null)
            {
                btnAnterior.Visible = (paginaAtual > 0);
                btnProximo.Visible = (paginaAtual < totalPaginas - 1);
            }
        }

        private void AdicionarTituloSecao()
        {
            Label lblTituloSecao = new Label();
            lblTituloSecao.Location = new Point(30, TxtBiografia.Bottom + 30);
            lblTituloSecao.Size = new Size(400, 35);
            lblTituloSecao.Text = "LIVROS SEMELHANTES";
            lblTituloSecao.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTituloSecao.ForeColor = Color.DarkBlue;
            lblTituloSecao.BackColor = Color.White;

            this.Controls.Add(lblTituloSecao);
        }

        private void AdicionarMensagemSemLivros(int y)
        {
            Label lblMensagem = new Label();
            lblMensagem.Location = new Point(30, y);
            lblMensagem.Size = new Size(400, 30);
            lblMensagem.Text = "Não foram encontrados livros semelhantes.";
            lblMensagem.Font = new Font("Arial", 10, FontStyle.Italic);
            lblMensagem.ForeColor = Color.Gray;
            lblMensagem.BackColor = Color.White;

            this.Controls.Add(lblMensagem);
        }
        private void BtnComprar1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Livro adicionado ao carrinho! 🛒", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PbCapa2_Click(object sender, EventArgs e)
        {

        }

        private void LblEditora2_Click(object sender, EventArgs e)
        {

        }

        private void LblGenero2_Click(object sender, EventArgs e)
        {

        }

        private void TxtDescricao_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtBiografia_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
