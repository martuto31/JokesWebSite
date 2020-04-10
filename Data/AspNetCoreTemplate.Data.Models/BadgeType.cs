namespace AspNetCoreTemplate.Data.Models
{
    public enum BadgeType
    {
        // da moje da si izbira koi badgove da mu se pokazvat
        User = 0,
        ActiveUser = 1, // vlizal e na stranicata pone vednuj na 2 dena za 6 dena.
        PopularUser = 2, // ima poveche ot 50 laika na vic
        Admin = 3,
        Owner = 4,
        Uploader = 5, // kachil e poveche ot 5 vica
        TopUser = 6, // kachil e pone 5 vica i ima pone 100 laika na vsichki vicove
        GoldenBadge = 7, // vliza vseki den pone vednuj, ima pone 3 kacheni vica ili 20 haresani ot nego vica
        GoodUser = 8, // ima pone 20 haresani vica,
        Top10Tochki = 9, // v top10 po tochki
        MostLikedUser = 10, // nomer 1 po tochki
        Top10Haresvaniq = 11, // top 10 po haresvani na vicove
        MostLikingUser = 11, // nomer 1 po haresani vicove
        Top10UploadedVicove = 12, // Top 10 po nai-mnogo kacheni vicove
        WithMostUploadedVicove = 13, // nomer 1 po nai-mnogo kacheni vicove
    }
}
