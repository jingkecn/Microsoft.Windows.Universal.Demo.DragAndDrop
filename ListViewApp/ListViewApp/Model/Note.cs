namespace ListViewApp.Model
{
    public partial class Note
    {
        private static int Count { get; set; }

        public string Content { get; set; }
        public string Title { get; set; } = $"Untitled - {++Count}";

        public string Information => $"\tTitle = {Title},\tContent = {Content}";

        public override string ToString()
        {
            return $"{base.ToString()}.{GetHashCode()}:\t{Information}";
        }
    }

    public partial class Note
    {
        public static readonly Note MyScriptNoteDefault = new Note
        {
            Title = "MyScript - The Power of Handwriting",
            Content =
                "MyScript is the source of the world’s most advanced technology for handwriting recognition and digital ink management. That’s why more than 350 million users are using MyScript to harness the power of digital handwriting at work, at home, and on the go."
        };

        public static readonly Note ChinaNoteEn = new Note
        {
            Title = "China",
            Content =
                "China, officially the People\'s Republic of China (PRC), is a unitary sovereign state in East Asia and the world\'s most populous country, with a population of around 1.404 billion.[13] Covering approximately 9,600,000 square kilometers (3,700,000 sq mi), it is the third- or fourth-largest country by total area,[j][19] depending on the source consulted. China also has the most neighbor countries in the world. Governed by the Communist Party of China, it exercises jurisdiction over 22 provinces, five autonomous regions, four direct-controlled municipalities (Beijing, Tianjin, Shanghai, and Chongqing), and the special administrative regions of Hong Kong and Macau."
        };

        public static readonly Note ChinaNoteZh = new Note
        {
            Title = "中國",
            Content =
                "中華人民共和國在亞東之極，都北京。其東以鴨綠江界朝鮮國。隔東海望日本。其北與俄羅斯、蒙古國相接。至東南海隅，民國是從。一九四九年十月元日，中華人民共和國立，都北平，改北京。立五大行政區，分中華為三十省，十二直轄市，五行署區，並自治區、地方、地區各一，多沿民國舊制。此後十數年間，數年一變，至一九六八年方定，時分廿二省、五自治區、三直轄市。省下分地級、縣級、鄉級，各地名號均異，按方俗名之。地級含地級市、地區、自治州、盟。縣級含市轄區、縣級市、縣、自治縣、旗、自治旗、特區、盟區。鄉級含區公所、鎮、鄉、蘇木、民族鄉、民族蘇木、街道。省級之長曰省委書記，省長居其左，以黨領事也。至一九九七年，香港特別行政區立，越二年，澳門特別行政區立，遂成今貌。分廿三省、五自治區、四直轄市、二特別行政區，合三十四部。"
        };

        public static readonly Note FranceNoteEn = new Note
        {
            Title = "France",
            Content =
                "France (French: [fʁɑ̃s]), officially the French Republic (French: République française [ʁepyblik fʁɑ̃sɛz]), is a country whose territory consists of metropolitan France in western Europe, as well as several overseas regions and territories.[XIII] The metropolitan area of France extends from the Mediterranean Sea to the English Channel and the North Sea, and from the Rhine to the Atlantic Ocean. The overseas territories include French Guiana in South America and several islands in the Atlantic, Pacific and Indian oceans. The country\'s 18 integral regions (five of which are situated overseas) span a combined area of 643,801 square kilometres (248,573 sq mi) which, as of October 2017, has a population of 67.15 million people.[10] France is a unitary semi-presidential republic with its capital in Paris, the country\'s largest city and main cultural and commercial centre. Other major urban centres include Marseille, Lyon, Lille, Nice, Toulouse and Bordeaux."
        };

        public static readonly Note FranceNoteZh = new Note
        {
            Title = "法國",
            Content =
                "法蘭西共和國（法文：République Française），日譯佛蘭西，中越簡稱法，日韓簡稱佛（法文：La France），立歐羅巴洲。國人多法蘭西人；國語法語。都巴黎，號花都。其為二世界大戰勝者之一也。越南舊譯坡郎沙、富郎沙、富浪沙、郎沙。其北為溫帶海洋性氣候，冬暖夏涼，全年皆雨，溫和宜人；南屬地中海型氣候，植柑橘、無花果、橄欖、葡萄等，夏熱冬暖，雨热异期；阿爾卑斯山屬高山氣候，常寒，長年覆有冰河。"
        };
    }
}