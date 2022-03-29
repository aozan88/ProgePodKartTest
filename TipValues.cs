using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProgePodKartTest
{

    class TipValues
    {
    }
    public abstract class ITip {
        public int[] position { get; set; }
        public Mode mode { get; set; }
        public ValueArrays values { get; set; }
        public decimal sendDataCode { get; set; }
    }

    public class BarkodData
    {
        public string UrunStokKodu { get; set; }
        public string UrunGrupKod { get; set; }
        public string UrunKodu { get; set; }
        public string UrunUretimTarihi { get; set; }
        public string UrunTestTarihi { get; set; }
    }

    #region Tip Siniflari
    public class Tip1 : ITip
    {
        public Tip1()
        {
            position = new int[6];
            mode = Mode.YAVAS;
            values = new ValueArrays();
            sendDataCode = 1;
        }
    }
    public class Tip2 : ITip
    {
        public Tip2()
        {
            position = new int[6];
            mode = Mode.YAVAS;
            values = new ValueArrays();
            sendDataCode = 2;
        }
    }
    public class Tip3 : ITip
    {
        public Tip3()
        {
            position = new int[6];
            mode = Mode.HIZLI;
            values = new ValueArrays();
            sendDataCode = 1;
        }
    }

    public class Tip4 : ITip
    {
        public Tip4()
        {
            position = new int[6];
            mode = Mode.YAVAS;
            values = new ValueArrays();
            sendDataCode = 4;
        }
    }

    public class Tip11 : ITip {
        public Tip11()
        {
            position = new int[6];
            mode = Mode.YAVAS;
            values = new ValueArrays();
            sendDataCode = 6;
        }
    }

    public class Tip12 : ITip
    {
        public Tip12()
        {
            position = new int[6];
            mode = Mode.HIZLI;
            values = new ValueArrays();
            sendDataCode = 1;
        }
    }

    public class Tip13 : ITip
    {
        public Tip13()
        {
            position = new int[6];
            mode = Mode.HIZLI;
            values = new ValueArrays();
            sendDataCode = 1;
        }
    }

    public class Tip21 : ITip
    {
        public Tip21()
        {
            position = new int[6];
            mode = Mode.HIZLI;
            values = new ValueArrays();
            sendDataCode = 1;
        }
    }
    public class Tip31 : ITip
    {
        public Tip31()
        {
            position = new int[6];
            mode = Mode.YAVAS;
            values = new ValueArrays();
            sendDataCode = 1;
        }
    }


    #endregion

    public class ValueArrays {
        // 1. tip = 11. tip AB-BC hızlı
        // 2. tip = 4. tip sadece BC
        // 4. tip = yavaşta 2 kere BC
        // 11. tip = AB'ler sonra BC'ler yavaşta
        // 
        public decimal[] altPozAB = new decimal[6]{   0,    6400, 15700, 24800, 33100, 42300     };
        public decimal[] ustPozAB = new decimal[6]{   1000, 10200, 21600, 31300, 44610, 51700   };
        public decimal[] altPozBC = new decimal[6]{   42300, 35900, 26600, 17500, 7090, 0     };
        public decimal[] ustPozBC = new decimal[6]{   50700, 41500, 30100, 20400, 9200, 100     };
    }

    #region ENUMS

    public enum Mode
    {
        HIZLI = 0,
        YAVAS = 1
    }
    public enum ValueType
    {
        [Description("AB")]
        AB = 0,
        [Description("BC")]
        BC = 1
    }

    public enum ProcedureStateForControls
    {
        // Anasayfa Acilis
        // Sadece Barkod Kontrolleri Aktif
        LoggedIn = 0,
        // Barkod Verisi Girildi
        // Barkod Kontrolleri Pasif, Tip Kontrolleri Aktif
        BarcodeInfoTaken = 1,
        // Barkod Verisi Güncellenmek / Değiştirilmek istendi
        // Barkod Kontrolleri Yeniden Aktif, Tip Kontrolleri Pasif
        BarcodeInfoToUpdate = 2,
        // Tip Secildi
        // Barkod gibi Tip Kontrolleri de Pasif
        TypeChosen = 3,
        // Tip Değiştirilmek İstendi / Tip Seçimi İptal
        // Barkod Pasif, Tip Kontrolleri de Aktif
        TypeToUpdate = 4,

    }
    #endregion

}
