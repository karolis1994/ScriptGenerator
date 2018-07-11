using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        //char conversion script generator button
        private void charConvButton_Click(object sender, EventArgs e)
        {
            if (charConvCheckedListBox.CheckedItems.Count > 0)
                if (charConvCheckedListBox.CheckedItems[0].ToString() == "Lithuanian")
                    scriptTextBox.Text = ConvertToLithuanianText(charConvTextBox.Text);
                else
                    scriptTextBox.Text = ConvertToRussianText(charConvTextBox.Text);
        }

        //char conversion checked list
        private void charConvCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Allow only one box to be checked
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < charConvCheckedListBox.Items.Count; ++ix)
                    if (e.Index != ix) charConvCheckedListBox.SetItemChecked(ix, false);
        }

        private String ReplaceWithCharset(String original, Dictionary<Int32, String> charset)
        {
            String result = original;

            foreach (KeyValuePair<Int32, String> pair in charset)
            {
                result = result.Replace(pair.Value, $"' || chr({pair.Key}) || '");
            }

            return result;
        }
        private String ConvertToLithuanianText(String original)
        {
            Dictionary<Int32, String> charset = new Dictionary<Int32, String>();
            charset.Add(128, "€");
            charset.Add(130, "‚");
            charset.Add(131, "ƒ");
            charset.Add(132, "„");
            charset.Add(133, "…");
            charset.Add(134, "†");
            charset.Add(135, "‡");
            charset.Add(136, "ˆ");
            charset.Add(137, "‰");
            charset.Add(139, "‹");
            charset.Add(140, "Œ");
            charset.Add(145, "‘");
            charset.Add(146, "’");
            charset.Add(147, "“");
            charset.Add(148, "”");
            charset.Add(149, "•");
            charset.Add(150, "–");
            charset.Add(151, "—");
            charset.Add(152, "˜");
            charset.Add(153, "™");
            charset.Add(155, "›");
            charset.Add(156, "œ");
            charset.Add(157, "�");
            charset.Add(159, "Ÿ");
            charset.Add(162, "¢");
            charset.Add(163, "£");
            charset.Add(164, "¤");
            charset.Add(166, "¦");
            charset.Add(167, "§");
            charset.Add(168, "Ø");
            charset.Add(169, "©");
            charset.Add(170, "Ŗ");
            charset.Add(171, "«");
            charset.Add(172, "¬");
            charset.Add(174, "®");
            charset.Add(175, "Æ");
            charset.Add(176, "°");
            charset.Add(177, "±");
            charset.Add(178, "²");
            charset.Add(179, "³");
            charset.Add(180, "´");
            charset.Add(181, "µ");
            charset.Add(182, "¶");
            charset.Add(183, "·");
            charset.Add(184, "ø");
            charset.Add(185, "¹");
            charset.Add(186, "ŗ");
            charset.Add(187, "»");
            charset.Add(188, "¼");
            charset.Add(189, "½");
            charset.Add(190, "¾");
            charset.Add(191, "æ");
            charset.Add(192, "Ą");
            charset.Add(193, "Į");
            charset.Add(194, "Ā");
            charset.Add(195, "Ć");
            charset.Add(196, "Ä");
            charset.Add(197, "Å");
            charset.Add(198, "Ę");
            charset.Add(199, "Ē");
            charset.Add(200, "Č");
            charset.Add(201, "É");
            charset.Add(202, "Ź");
            charset.Add(203, "Ė");
            charset.Add(204, "Ģ");
            charset.Add(205, "Ķ");
            charset.Add(206, "Ī");
            charset.Add(207, "Ļ");
            charset.Add(208, "Š");
            charset.Add(209, "Ń");
            charset.Add(210, "Ņ");
            charset.Add(211, "Ó");
            charset.Add(212, "Ō");
            charset.Add(213, "Õ");
            charset.Add(214, "Ö");
            charset.Add(215, "×");
            charset.Add(216, "Ų");
            charset.Add(217, "Ł");
            charset.Add(218, "Ś");
            charset.Add(219, "Ū");
            charset.Add(220, "Ü");
            charset.Add(221, "Ż");
            charset.Add(222, "Ž");
            charset.Add(223, "ß");
            charset.Add(224, "ą");
            charset.Add(225, "į");
            charset.Add(226, "ā");
            charset.Add(227, "ć");
            charset.Add(228, "ä");
            charset.Add(229, "å");
            charset.Add(230, "ę");
            charset.Add(231, "ē");
            charset.Add(232, "č");
            charset.Add(233, "é");
            charset.Add(234, "ź");
            charset.Add(235, "ė");
            charset.Add(236, "ģ");
            charset.Add(237, "ķ");
            charset.Add(238, "ī");
            charset.Add(239, "ļ");
            charset.Add(240, "š");
            charset.Add(241, "ń");
            charset.Add(242, "ņ");
            charset.Add(243, "ó");
            charset.Add(244, "ō");
            charset.Add(245, "õ");
            charset.Add(246, "ö");
            charset.Add(247, "÷");
            charset.Add(248, "ų");
            charset.Add(249, "ł");
            charset.Add(250, "ś");
            charset.Add(251, "ū");
            charset.Add(252, "ü");
            charset.Add(253, "ż");
            charset.Add(254, "ž");
            charset.Add(255, "˙");

            String result = ReplaceWithCharset(original, charset);

            return result;
        }
        public String ConvertToRussianText(String original)
        {
            Dictionary<Int32, String> charset = new Dictionary<Int32, String>();
            charset.Add(128, "€");
            charset.Add(130, "‚");
            charset.Add(131, "ƒ");
            charset.Add(132, "„");
            charset.Add(133, "…");
            charset.Add(134, "†");
            charset.Add(135, "‡");
            charset.Add(136, "ˆ");
            charset.Add(137, "‰");
            charset.Add(139, "‹");
            charset.Add(140, "Œ");
            charset.Add(145, "‘");
            charset.Add(146, "’");
            charset.Add(147, "“");
            charset.Add(148, "”");
            charset.Add(149, "•");
            charset.Add(150, "–");
            charset.Add(151, "—");
            charset.Add(152, "˜");
            charset.Add(153, "™");
            charset.Add(155, "›");
            charset.Add(156, "œ");
            charset.Add(157, "�");
            charset.Add(159, "Ÿ");
            charset.Add(161, "Ў");
            charset.Add(162, "ў");
            charset.Add(163, "Ј");
            charset.Add(164, "¤");
            charset.Add(165, "Ґ");
            charset.Add(166, "¦");
            charset.Add(167, "§");
            charset.Add(168, "Ё");
            charset.Add(169, "©");
            charset.Add(170, "Є");
            charset.Add(171, "«");
            charset.Add(172, "¬");
            charset.Add(174, "®");
            charset.Add(175, "Ї");
            charset.Add(176, "°");
            charset.Add(177, "±");
            charset.Add(178, "І");
            charset.Add(179, "і");
            charset.Add(180, "ґ");
            charset.Add(181, "µ");
            charset.Add(182, "¶");
            charset.Add(183, "·");
            charset.Add(184, "ё");
            charset.Add(185, "№");
            charset.Add(186, "є");
            charset.Add(187, "»");
            charset.Add(188, "ј");
            charset.Add(189, "Ѕ");
            charset.Add(190, "ѕ");
            charset.Add(191, "ї");
            charset.Add(192, "А");
            charset.Add(193, "Б");
            charset.Add(194, "В");
            charset.Add(195, "Г");
            charset.Add(196, "Д");
            charset.Add(197, "Е");
            charset.Add(198, "Ж");
            charset.Add(199, "З");
            charset.Add(200, "И");
            charset.Add(201, "Й");
            charset.Add(202, "К");
            charset.Add(203, "Л");
            charset.Add(204, "М");
            charset.Add(205, "Н");
            charset.Add(206, "О");
            charset.Add(207, "П");
            charset.Add(208, "Р");
            charset.Add(209, "С");
            charset.Add(210, "Т");
            charset.Add(211, "У");
            charset.Add(212, "Ф");
            charset.Add(213, "Х");
            charset.Add(214, "Ц");
            charset.Add(215, "Ч");
            charset.Add(216, "Ш");
            charset.Add(217, "Щ");
            charset.Add(218, "Ъ");
            charset.Add(219, "Ы");
            charset.Add(220, "Ь");
            charset.Add(221, "Э");
            charset.Add(222, "Ю");
            charset.Add(223, "Я");
            charset.Add(224, "а");
            charset.Add(225, "б");
            charset.Add(226, "в");
            charset.Add(227, "г");
            charset.Add(228, "д");
            charset.Add(229, "е");
            charset.Add(230, "ж");
            charset.Add(231, "з");
            charset.Add(232, "и");
            charset.Add(233, "й");
            charset.Add(234, "к");
            charset.Add(235, "л");
            charset.Add(236, "м");
            charset.Add(237, "н");
            charset.Add(238, "о");
            charset.Add(239, "п");
            charset.Add(240, "р");
            charset.Add(241, "с");
            charset.Add(242, "т");
            charset.Add(243, "у");
            charset.Add(244, "ф");
            charset.Add(245, "х");
            charset.Add(246, "ц");
            charset.Add(247, "ч");
            charset.Add(248, "ш");
            charset.Add(249, "щ");
            charset.Add(250, "ъ");
            charset.Add(251, "ы");
            charset.Add(252, "ь");
            charset.Add(253, "э");
            charset.Add(254, "ю");
            charset.Add(255, "я");

            String result = ReplaceWithCharset(original, charset);

            return result;
        }
    }
}
