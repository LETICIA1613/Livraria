using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
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
            public Point PosDescricao { get; set; }
            public Point PosBiografia { get; set; }
            public Point PosImagem { get; set; }

            public Size TamTitulo { get; set; }
            public Size TamAutor { get; set; }
            public Size TamBiografia { get; set; }
            public Size TamDescricao { get; set; }
            public Size TamImagem { get; set; }
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
