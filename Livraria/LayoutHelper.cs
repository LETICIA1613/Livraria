using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace Livraria
{
    public static class LayoutHelper
    {
        private static readonly string CaminhoArquivo = "layout_perfil.json";
        public class LayoutInfo
        {
            public Point PosTitulo { get; set; }
            public Point PosAutor { get; set; }
            public Point PosEditora { get; set; }
            public Point PosGenero { get; set; }
            public Point PosFaixaEtaria { get; set; }
            public Point PosPreco { get; set; }
            public Point PosDescricao { get; set; }
            public Point PosBiografia { get; set; }
            public Point PosInformacao { get; set; }
            public Point PosImagem { get; set; }
            public Point PosInforFX { get; set; }
            public Point PosInforGen { get; set; }
            public Point PosInforEdi { get; set; }
            public Point PosInforEdiRes { get; set; }
            public Point PosInforAutor { get; set; }
            public Point PosInforAutorRes { get; set; }
            public Point PosInforNome { get; set; }
            public Point PosInforNomeRes { get; set; }
            public Point PosInforNaci { get; set; }
            public Point PosInforNaciRes { get; set; }
            public Point PosBio { get; set; }
            public Point PosDes { get; set; }
            public Point PosBtnComprar { get; set; }

            public Size TamTitulo { get; set; }
            public Size TamAutor { get; set; }
            public Size TamEditora { get; set; }
            public Size TamGenero { get; set; }
            public Size TamFaixaEtaria { get; set; }
            public Size TamPreco { get; set; }
            public Size TamDescricao { get; set; }
            public Size TamBiografia { get; set; }
            public Size TamImagem { get; set; }
            public Size TamInformacao { get; set; }
            public Size TamInforNome { get; set; }
            public Size TamInforNomeRes { get; set; }
            public Size TamInforEdi { get; set; }
            public Size TamInforEdiRes { get; set; }
            public Size TamInforNaci { get; set; }
            public Size TamInforNaciRes { get; set; }
            public Size TamInforFX { get; set; }
            public Size TamInforGen { get; set; }
            public Size TamInforAutor { get; set; }
            public Size TamInforAutorRes { get; set; }
            public Size TamBio { get; set; }
            public Size TamDes { get; set; }
            public Size TamBtnComprar { get; set; }

            public Point PosLivrosSemelhantes { get; set; }
            public Size TamLivrosSemelhantes { get; set; }
            public Point PosBotaoCarrinho { get; set; }
            public Size TamBotaoCarrinho { get; set; }
        }

        public static void Salvar(LayoutInfo layout)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string json = JsonSerializer.Serialize(layout, options);
                File.WriteAllText(CaminhoArquivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar layout: {ex.Message}", ex);
            }
        }

        public static LayoutInfo Carregar()
        {
            if (!File.Exists(CaminhoArquivo))
            {
                return CriarLayoutPadrao();
            }

            try
            {
                string json = File.ReadAllText(CaminhoArquivo);
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var layout = JsonSerializer.Deserialize<LayoutInfo>(json, options);

                return layout ?? CriarLayoutPadrao();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar layout: {ex.Message}");
                try { File.Delete(CaminhoArquivo); } catch { }
                return CriarLayoutPadrao();
            }
        }

        private static LayoutInfo CriarLayoutPadrao()
        {

            return new LayoutInfo
            {
                // POSIÇÕES (usando os nomes corretos que você me passou)
                PosImagem = new Point(30, 30),
                PosTitulo = new Point(200, 30),
                PosAutor = new Point(200, 70),
                PosEditora = new Point(200, 100),
                PosPreco = new Point(200, 130),
                PosDes = new Point(30, 300),
                PosDescricao = new Point(30, 330),
                PosInformacao = new Point(30, 470),
                PosInforNome = new Point(30, 500),
                PosInforNomeRes = new Point(120, 500),
                PosInforAutor = new Point(30, 530),
                PosInforAutorRes = new Point(120, 530),
                PosInforNaci = new Point(30, 560),
                PosInforNaciRes = new Point(180, 560),
                PosInforEdi = new Point(30, 590),
                PosInforEdiRes = new Point(120, 590),
                PosInforFX = new Point(30, 620),
                PosFaixaEtaria = new Point(140, 620),
                PosInforGen = new Point(30, 650),
                PosGenero = new Point(120, 650),
                PosBio = new Point(30, 690),
                PosBiografia = new Point(30, 720),

                // TAMANHOS
                TamImagem = new Size(150, 220),
                TamTitulo = new Size(400, 35),
                TamAutor = new Size(400, 25),
                TamEditora = new Size(400, 25),
                TamPreco = new Size(200, 30),
                TamDes = new Size(200, 25),
                TamDescricao = new Size(600, 120),
                TamInformacao = new Size(200, 25),
                TamInforNome = new Size(80, 25),
                TamInforNomeRes = new Size(400, 25),
                TamInforAutor = new Size(80, 25),
                TamInforAutorRes = new Size(400, 25),
                TamInforNaci = new Size(150, 25),
                TamInforNaciRes = new Size(400, 25),
                TamInforEdi = new Size(80, 25),
                TamInforEdiRes = new Size(400, 25),
                TamInforFX = new Size(100, 25),
                TamFaixaEtaria = new Size(400, 25),
                TamInforGen = new Size(80, 25),
                TamGenero = new Size(500, 55),
                TamBio = new Size(200, 25),
                TamBiografia = new Size(700, 250),


                PosLivrosSemelhantes = new Point(30, 800), // Ajuste conforme necessário
                TamLivrosSemelhantes = new Size(600, 200)

            };
        }
        
    }
};
        
    
        /* if (!File.Exists(CaminhoArquivo))
             return null;

         string json = File.ReadAllText(CaminhoArquivo);
         return JsonSerializer.Deserialize<LayoutInfo>(json);
        */
    


