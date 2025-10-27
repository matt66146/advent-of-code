namespace Day10
{



    public class ElementInfo
    {
        public string Name { get; set; }
        public string Sequence { get; set; }
        public List<string> DecaysInto { get; set; }
        public double Abundance { get; set; }

        public static Dictionary<string, ElementInfo> elements = new Dictionary<string, ElementInfo>
        {
            ["H"] = new ElementInfo
            {
                Name = "H",
                Sequence = "22",
                DecaysInto = new List<string> { "H" },
                Abundance = 91790.383216
            },
            ["He"] = new ElementInfo
            {
                Name = "He",
                Sequence = "13112221133211322112211213322112",
                DecaysInto = new List<string> { "Hf", "Pa", "H", "Ca", "Li" },
                Abundance = 3237.2968588
            },
            ["Li"] = new ElementInfo
            {
                Name = "Li",
                Sequence = "312211322212221121123222112",
                DecaysInto = new List<string> { "He" },
                Abundance = 4220.0665982
            },
            ["Be"] = new ElementInfo
            {
                Name = "Be",
                Sequence = "111312211312113221133211322112211213322112",
                DecaysInto = new List<string> { "Ge", "Ca", "Li" },
                Abundance = 2263.8860325
            },
            ["B"] = new ElementInfo
            {
                Name = "B",
                Sequence = "1321132122211322212221121123222112",
                DecaysInto = new List<string> { "Be" },
                Abundance = 2951.1503716
            },
            ["C"] = new ElementInfo
            {
                Name = "C",
                Sequence = "3113112211322112211213322112",
                DecaysInto = new List<string> { "B" },
                Abundance = 3847.0525419
            },
            ["N"] = new ElementInfo
            {
                Name = "N",
                Sequence = "111312212221121123222112",
                DecaysInto = new List<string> { "C" },
                Abundance = 5014.9302464
            },
            ["O"] = new ElementInfo
            {
                Name = "O",
                Sequence = "132112211213322112",
                DecaysInto = new List<string> { "N" },
                Abundance = 6537.3490750
            },
            ["F"] = new ElementInfo
            {
                Name = "F",
                Sequence = "31121123222112",
                DecaysInto = new List<string> { "O" },
                Abundance = 8521.9396539
            },
            ["Ne"] = new ElementInfo
            {
                Name = "Ne",
                Sequence = "111213322112",
                DecaysInto = new List<string> { "F" },
                Abundance = 11109.006696
            },
            ["Na"] = new ElementInfo
            {
                Name = "Na",
                Sequence = "123222112",
                DecaysInto = new List<string> { "Ne" },
                Abundance = 14481.448773
            },
            ["Mg"] = new ElementInfo
            {
                Name = "Mg",
                Sequence = "3113322112",
                DecaysInto = new List<string> { "Pm", "Na" },
                Abundance = 18850.441228
            },
            ["Al"] = new ElementInfo
            {
                Name = "Al",
                Sequence = "1113222112",
                DecaysInto = new List<string> { "Mg" },
                Abundance = 24573.006696
            },
            ["Si"] = new ElementInfo
            {
                Name = "Si",
                Sequence = "1322112",
                DecaysInto = new List<string> { "Al" },
                Abundance = 32032.812960
            },
            ["P"] = new ElementInfo
            {
                Name = "P",
                Sequence = "311311222112",
                DecaysInto = new List<string> { "Ho", "Si" },
                Abundance = 14895.886658
            },
            ["S"] = new ElementInfo
            {
                Name = "S",
                Sequence = "1113122112",
                DecaysInto = new List<string> { "P" },
                Abundance = 19417.939250
            },
            ["Cl"] = new ElementInfo
            {
                Name = "Cl",
                Sequence = "132112",
                DecaysInto = new List<string> { "S" },
                Abundance = 25312.784218
            },
            ["Ar"] = new ElementInfo
            {
                Name = "Ar",
                Sequence = "3112",
                DecaysInto = new List<string> { "Cl" },
                Abundance = 32997.170122
            },
            ["K"] = new ElementInfo
            {
                Name = "K",
                Sequence = "1112",
                DecaysInto = new List<string> { "Ar" },
                Abundance = 43014.360913
            },
            ["Ca"] = new ElementInfo
            {
                Name = "Ca",
                Sequence = "12",
                DecaysInto = new List<string> { "K" },
                Abundance = 56072.543129
            },
            ["Sc"] = new ElementInfo { Name = "Sc", Sequence = "3113112221133112", DecaysInto = new List<string> { "Ho", "Pa", "H", "Ca", "Co" }, Abundance = 9302.0974443 },
            ["Ti"] = new ElementInfo { Name = "Ti", Sequence = "11131221131112", DecaysInto = new List<string> { "Sc" }, Abundance = 12126.002783 },
            ["V"] = new ElementInfo { Name = "V", Sequence = "13211312", DecaysInto = new List<string> { "Ti" }, Abundance = 15807.181592 },
            ["Cr"] = new ElementInfo { Name = "Cr", Sequence = "31132", DecaysInto = new List<string> { "V" }, Abundance = 20605.882611 },
            ["Mn"] = new ElementInfo { Name = "Mn", Sequence = "111311222112", DecaysInto = new List<string> { "Cr", "Si" }, Abundance = 26861.360180 },
            ["Fe"] = new ElementInfo { Name = "Fe", Sequence = "13122112", DecaysInto = new List<string> { "Mn" }, Abundance = 35015.858546 },
            ["Co"] = new ElementInfo { Name = "Co", Sequence = "32112", DecaysInto = new List<string> { "Fe" }, Abundance = 45645.877256 },
            ["Ni"] = new ElementInfo { Name = "Ni", Sequence = "11133112", DecaysInto = new List<string> { "Zn", "Co" }, Abundance = 13871.123200 },
            ["Cu"] = new ElementInfo { Name = "Cu", Sequence = "131112", DecaysInto = new List<string> { "Ni" }, Abundance = 18082.082203 },
            ["Zn"] = new ElementInfo { Name = "Zn", Sequence = "312", DecaysInto = new List<string> { "Cu" }, Abundance = 23571.391336 },
            ["Ga"] = new ElementInfo { Name = "Ga", Sequence = "13221133122211332", DecaysInto = new List<string> { "Eu", "Ca", "Ac", "H", "Ca", "Zn" }, Abundance = 1447.8905642 },
            ["Ge"] = new ElementInfo { Name = "Ge", Sequence = "31131122211311122113222", DecaysInto = new List<string> { "Ho", "Ga" }, Abundance = 1887.4372276 },
            ["As"] = new ElementInfo { Name = "As", Sequence = "11131221131211322113322112", DecaysInto = new List<string> { "Ge", "Na" }, Abundance = 27.246216076 },
            ["Se"] = new ElementInfo { Name = "Se", Sequence = "13211321222113222112", DecaysInto = new List<string> { "As" }, Abundance = 35.517547944 },
            ["Br"] = new ElementInfo { Name = "Br", Sequence = "3113112211322112", DecaysInto = new List<string> { "Se" }, Abundance = 46.299868152 },
            ["Kr"] = new ElementInfo { Name = "Kr", Sequence = "11131221222112", DecaysInto = new List<string> { "Br" }, Abundance = 60.355455682 },
            ["Rb"] = new ElementInfo { Name = "Rb", Sequence = "1321122112", DecaysInto = new List<string> { "Kr" }, Abundance = 78.678000089 },
            ["Sr"] = new ElementInfo { Name = "Sr", Sequence = "3112112", DecaysInto = new List<string> { "Rb" }, Abundance = 102.56285249 },
            ["Y"] = new ElementInfo { Name = "Y", Sequence = "1112133", DecaysInto = new List<string> { "Sr", "U" }, Abundance = 133.69860315 },
            ["Zr"] = new ElementInfo { Name = "Zr", Sequence = "12322211331222113112211", DecaysInto = new List<string> { "Y", "H", "Ca", "Tc" }, Abundance = 174.28645997 },
            ["Nb"] = new ElementInfo { Name = "Nb", Sequence = "1113122113322113111221131221", DecaysInto = new List<string> { "Er", "Zr" }, Abundance = 227.19586752 },
            ["Mo"] = new ElementInfo { Name = "Mo", Sequence = "13211322211312113211", DecaysInto = new List<string> { "Nb" }, Abundance = 296.16736852 },
            ["Tc"] = new ElementInfo { Name = "Tc", Sequence = "311322113212221", DecaysInto = new List<string> { "Mo" }, Abundance = 386.07704943 },
            ["Ru"] = new ElementInfo { Name = "Ru", Sequence = "132211331222113112211", DecaysInto = new List<string> { "Eu", "Ca", "Tc" }, Abundance = 328.99480576 },
            ["Rh"] = new ElementInfo { Name = "Rh", Sequence = "311311222113111221131221", DecaysInto = new List<string> { "Ho", "Ru" }, Abundance = 428.87015041 },
            ["Pd"] = new ElementInfo { Name = "Pd", Sequence = "111312211312113211", DecaysInto = new List<string> { "Rh" }, Abundance = 559.06537946 },
            ["Ag"] = new ElementInfo { Name = "Ag", Sequence = "132113212221", DecaysInto = new List<string> { "Pd" }, Abundance = 728.78492056 },
            ["Cd"] = new ElementInfo { Name = "Cd", Sequence = "3113112211", DecaysInto = new List<string> { "Ag" }, Abundance = 950.02745646 },
            ["In"] = new ElementInfo { Name = "In", Sequence = "11131221", DecaysInto = new List<string> { "Cd" }, Abundance = 1238.4341972 },
            ["Sn"] = new ElementInfo { Name = "Sn", Sequence = "13211", DecaysInto = new List<string> { "In" }, Abundance = 1614.3946687 },
            ["Sb"] = new ElementInfo { Name = "Sb", Sequence = "3112221", DecaysInto = new List<string> { "Pm", "Sn" }, Abundance = 2104.4881933 },
            ["Te"] = new ElementInfo { Name = "Te", Sequence = "1322113312211", DecaysInto = new List<string> { "Eu", "Ca", "Sb" }, Abundance = 2743.3629718 },
            ["I"] = new ElementInfo { Name = "I", Sequence = "311311222113111221", DecaysInto = new List<string> { "Ho", "Te" }, Abundance = 3576.1856107 },
            ["Xe"] = new ElementInfo { Name = "Xe", Sequence = "11131221131211", DecaysInto = new List<string> { "I" }, Abundance = 4661.8342720 },
            ["Cs"] = new ElementInfo { Name = "Cs", Sequence = "13211321", DecaysInto = new List<string> { "Xe" }, Abundance = 6077.0611889 },
            ["Ba"] = new ElementInfo { Name = "Ba", Sequence = "311311", DecaysInto = new List<string> { "Cs" }, Abundance = 7921.9188284 },
            ["La"] = new ElementInfo { Name = "La", Sequence = "11131", DecaysInto = new List<string> { "Ba" }, Abundance = 10326.833312 },
            ["Ce"] = new ElementInfo { Name = "Ce", Sequence = "1321133112", DecaysInto = new List<string> { "La", "H", "Ca", "Co" }, Abundance = 13461.825166 },
            ["Pr"] = new ElementInfo { Name = "Pr", Sequence = "31131112", DecaysInto = new List<string> { "Ce" }, Abundance = 17548.529287 },
            ["Nd"] = new ElementInfo { Name = "Nd", Sequence = "111312", DecaysInto = new List<string> { "Pr" }, Abundance = 22875.863883 },
            ["Pm"] = new ElementInfo { Name = "Pm", Sequence = "132", DecaysInto = new List<string> { "Nd" }, Abundance = 29820.456167 },
            ["Sm"] = new ElementInfo { Name = "Sm", Sequence = "311332", DecaysInto = new List<string> { "Pm", "Ca", "Zn" }, Abundance = 15408.115182 },
            ["Eu"] = new ElementInfo { Name = "Eu", Sequence = "1113222", DecaysInto = new List<string> { "Sm" }, Abundance = 20085.668709 },
            ["Gd"] = new ElementInfo
            {
                Name = "Gd",
                Sequence = "13221133112",
                DecaysInto = new List<string> { "Eu", "Ca", "Co" },
                Abundance = 21662.972821
            },
            ["Tb"] = new ElementInfo
            {
                Name = "Tb",
                Sequence = "3113112221131112",
                DecaysInto = new List<string> { "Ho", "Gd" },
                Abundance = 28239.358949
            },
            ["Dy"] = new ElementInfo
            {
                Name = "Dy",
                Sequence = "111312211312",
                DecaysInto = new List<string> { "Tb" },
                Abundance = 36812.186418
            },
            ["Ho"] = new ElementInfo
            {
                Name = "Ho",
                Sequence = "1321132",
                DecaysInto = new List<string> { "Dy" },
                Abundance = 47987.529438
            },
            ["Er"] = new ElementInfo
            {
                Name = "Er",
                Sequence = "311311222",
                DecaysInto = new List<string> { "Ho", "Pm" },
                Abundance = 1098.5955997
            },
            ["Tm"] = new ElementInfo
            {
                Name = "Tm",
                Sequence = "11131221133112",
                DecaysInto = new List<string> { "Er", "Ca", "Co" },
                Abundance = 1204.9083841
            },
            ["Yb"] = new ElementInfo
            {
                Name = "Yb",
                Sequence = "1321131112",
                DecaysInto = new List<string> { "Tm" },
                Abundance = 1570.6911808
            },
            ["Lu"] = new ElementInfo
            {
                Name = "Lu",
                Sequence = "311312",
                DecaysInto = new List<string> { "Yb" },
                Abundance = 2047.5173200
            },
            ["Hf"] = new ElementInfo
            {
                Name = "Hf",
                Sequence = "11132",
                DecaysInto = new List<string> { "Lu" },
                Abundance = 2669.0970363
            },
            ["Ta"] = new ElementInfo
            {
                Name = "Ta",
                Sequence = "13112221133211322112211213322113",
                DecaysInto = new List<string> { "Hf", "Pa", "H", "Ca", "W" },
                Abundance = 242.07736666
            },
            ["W"] = new ElementInfo
            {
                Name = "W",
                Sequence = "312211322212221121123222113",
                DecaysInto = new List<string> { "Ta" },
                Abundance = 315.56655252
            },
            ["Re"] = new ElementInfo
            {
                Name = "Re",
                Sequence = "111312211312113221133211322112211213322113",
                DecaysInto = new List<string> { "Ge", "Ca", "W" },
                Abundance = 169.28801808
            },
            ["Os"] = new ElementInfo
            {
                Name = "Os",
                Sequence = "1321132122211322212221121123222113",
                DecaysInto = new List<string> { "Re" },
                Abundance = 220.68001229
            },
            ["Ir"] = new ElementInfo
            {
                Name = "Ir",
                Sequence = "3113112211322112211213322113",
                DecaysInto = new List<string> { "Os" },
                Abundance = 287.67344775
            },
            ["Pt"] = new ElementInfo
            {
                Name = "Pt",
                Sequence = "111312212221121123222113",
                DecaysInto = new List<string> { "Ir" },
                Abundance = 375.00456738
            },
            ["Au"] = new ElementInfo
            {
                Name = "Au",
                Sequence = "132112211213322113",
                DecaysInto = new List<string> { "Pt" },
                Abundance = 488.84742982
            },
            ["Hg"] = new ElementInfo
            {
                Name = "Hg",
                Sequence = "31121123222113",
                DecaysInto = new List<string> { "Au" },
                Abundance = 637.25039755
            },
            ["Tl"] = new ElementInfo
            {
                Name = "Tl",
                Sequence = "111213322113",
                DecaysInto = new List<string> { "Hg" },
                Abundance = 830.70513293
            },
            ["Pb"] = new ElementInfo
            {
                Name = "Pb",
                Sequence = "123222113",
                DecaysInto = new List<string> { "Tl" },
                Abundance = 1082.8883285
            },
            ["Bi"] = new ElementInfo
            {
                Name = "Bi",
                Sequence = "3113322113",
                DecaysInto = new List<string> { "Pm", "Pb" },
                Abundance = 1411.6286100
            },
            ["Po"] = new ElementInfo
            {
                Name = "Po",
                Sequence = "1113222113",
                DecaysInto = new List<string> { "Bi" },
                Abundance = 1840.1669683
            },
            ["At"] = new ElementInfo
            {
                Name = "At",
                Sequence = "1322113",
                DecaysInto = new List<string> { "Po" },
                Abundance = 2398.7998311
            },
            ["Rn"] = new ElementInfo
            {
                Name = "Rn",
                Sequence = "311311222113",
                DecaysInto = new List<string> { "Ho", "At" },
                Abundance = 3127.0209328
            },
            ["Fr"] = new ElementInfo
            {
                Name = "Fr",
                Sequence = "1113122113",
                DecaysInto = new List<string> { "Rn" },
                Abundance = 4076.3134078
            },
            ["Ra"] = new ElementInfo
            {
                Name = "Ra",
                Sequence = "132113",
                DecaysInto = new List<string> { "Fr" },
                Abundance = 5313.7894999
            },
            ["Ac"] = new ElementInfo
            {
                Name = "Ac",
                Sequence = "3113",
                DecaysInto = new List<string> { "Ra" },
                Abundance = 6926.9352045
            },
            ["Th"] = new ElementInfo
            {
                Name = "Th",
                Sequence = "1113",
                DecaysInto = new List<string> { "Ac" },
                Abundance = 7581.9047125
            },
            ["Pa"] = new ElementInfo
            {
                Name = "Pa",
                Sequence = "13",
                DecaysInto = new List<string> { "Th" },
                Abundance = 9883.5986392
            },
            ["U"] = new ElementInfo
            {
                Name = "U",
                Sequence = "3",
                DecaysInto = new List<string> { "Pa" },
                Abundance = 102.56285249
            }
            /*
            ["Np"] = new ElementInfo
            {
                Name = "Np",
                Sequence = "1311222113321132211221121332211n[note 1]",
                DecaysInto = new List<string> { "Hf", "Pa", "H", "Ca", "Pu" },
                Abundance = 0
            },
            ["Pu"] = new ElementInfo
            {
                Name = "Pu",
                Sequence = "31221132221222112112322211n[note 1]",
                DecaysInto = new List<string> { "Np" },
                Abundance = 0
            }
            */
        };

    }
}
