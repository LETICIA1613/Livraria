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
            public Point PosEditora2 { get; set; }
            public Point PosGenero { get; set; }
            public Point PosFaixaEtaria { get; set; }
            public Point PosPreco { get; set; }
            public Point PosDescricao { get; set; }
            public Point PosBiografia { get; set; }
            public Point PosInformacao { get; set; }
            public Point PosImagem { get; set; }
            public Point PosInfoFX { get; set; }
            public Point PosInfoGen { get; set; }
            public Point PosInfoEdi { get; set; }
            public Point PosInfoEdiRes { get; set; }
            public Point PosInforAutor { get; set; }
            public Point PosInforAutor2 { get; set; }
            public Point PosInforNome { get; set; }
            public Point PosInforNomeRes { get; set; }
            public Point PosInforNaci { get; set; }
            public Point PosInforNaciRes { get; set; }
            public Point PosBio { get; set; }
            public Point PosDes { get; set; }


            public Size TamTitulo { get; set; }
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
            public Size TamAutor { get; set; }
            public Size TamEditora { get; set; }
            public Size TamEditora2 { get; set; }
            public Size TamGenero { get; set; }
            public Size TamFaixaEtaria { get; set; }
            public Size TamPreco { get; set; }
            public Size TamBiografia { get; set; }
            public Size TamDescricao { get; set; }
            public Size TamImagem { get; set; }
            public Size TamDes { get; set; }
        }

        public static void Salvar(LayoutInfo layout)
        {
            string json = JsonSerializer.Serialize(layout, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CaminhoArquivo, json);
        }

        public static LayoutInfo Carregar()
        {
            if (!File.Exists(CaminhoArquivo))
                return null;

            string json = File.ReadAllText(CaminhoArquivo);
            return JsonSerializer.Deserialize<LayoutInfo>(json);
        }
    }
}
