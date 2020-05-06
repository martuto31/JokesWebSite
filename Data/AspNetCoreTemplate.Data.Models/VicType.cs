namespace AspNetCoreTemplate.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum VicType
    {
        [Display(Name = "Бай Ганьо")]
        BaiGanio = 1,

        [Display(Name = "Блондинки")]
        Blondinki = 2,

        [Display(Name = "Черен Хумор")]
        CherenHumor = 3,

        [Display(Name = "Иванчо и Марийка")]
        IvanchoIMariika = 4,

        [Display(Name = "Лафоризми")]
        Laforizmi = 5,

        [Display(Name = "Луди")]
        Ludi = 6,

        [Display(Name = "Мръсни")]
        Mrusni = 7,

        [Display(Name = "Мутри")]
        Mutri = 8,

        [Display(Name = "Пияници")]
        Piqnici = 9,

        [Display(Name = "Полицаи")]
        Policai = 10,

        [Display(Name = "Животни")]
        Zhivotni = 11,

        [Display(Name = "Радио Ереван")]
        RadioErevan = 12,

        [Display(Name = "Тъпизми")]
        Tupizmi = 13,

        [Display(Name = "Ученически бисери")]
        UchenicheskiBiseri = 14,
    }
}
