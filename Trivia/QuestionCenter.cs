using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Trivia
{
    public class QuestionCenter
    {
        const string QUESTIONS_FILE_NAME = @"C:\Trivia\Trivia\Questions\questions.xml";        
        int _id;
        MultiChoiceQuestion[] _questions;
        /*
        MultiChoiceQuestion[] _questions =
        {
            new MultiChoiceQuestion{Question="Why is it traditional to eat apples and honey on Rosh Hashanah?",
                                    A="To symbolize a healthy new year",
                                    B="To symbolize a sweet new year",
                                    C="The apple symbolizes the earth and the honey symbolizes heaven",
                                    D="Moses was said to eat 100 apples on the first day of each new year",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Apple.jpg"},

            new MultiChoiceQuestion{Question="Out of all the fruits, why do we dip apples with honey in Rosh Hashanah?", 
                                    A="It is delicious", 
                                    B="Apples were available in Israel during this season", 
                                    C="Because it says so in the bible", 
                                    D="Because apples are mentioned in the Adam and Eve story in the story of genesis",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="ApplesAndHoney.jpg"},

            new MultiChoiceQuestion{Question="In order for the Etrog (citron) to be certified as kosher for use in the ritual of Lulav, what must not fall off?",
                                    A="Pitom (Stem)",
                                    B="Good smell",
                                    C="Ripeness",
                                    D="Leaves",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="ArbaatHaminim.jpg"},

            new MultiChoiceQuestion{Question="It's customary to eat what on the second night of Rosh Hashanah?",
                                    A="A new fruit you haven't eaten that year",
                                    B="A vegetable you normally hate",
                                    C="Any fried food",
                                    D="Matzah with butter",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Avatar.jpg"},

            new MultiChoiceQuestion{Question="Because an etrog has both a taste and a smell, it symbolizes a person who...",
                                    A="knows Torah and performs good deeds",
                                    B="knows Torah and is regarded as a scholar",
                                    C="knows Torah and is a community leader",
                                    D="observes the mitzvot and performs good deeds",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Gold,
                                    ImageTag="Ballarina.jpg"},

            new MultiChoiceQuestion{Question="The day of fasting that occurs immediately after Rosh Hashana is called?",
                                    A="Tzom Gedalia",
                                    B="Yom Kippur",
                                    C="Tishah Beav",
                                    D="Taanit Ester",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Batman.jpg"},

            new MultiChoiceQuestion{Question="It is a custom for how many people to be honored with an aliyah on Simchat Torah?",
                                    A="All the children in the congregation",
                                    B="The whole congregation",
                                    C="The Rabbi",
                                    D="The kohanim",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Gold,
                                    ImageTag="Chima.jpg"},

            new MultiChoiceQuestion{Question="If Rosh Hashanah falls on Shabbat we:",
                                    A="blow the shofar",
                                    B="blow a clarinet instead of the shofar",
                                    C="don't blow the shofar",
                                    D="put the shofar back on the ram",
                                    Answer ="C",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Dobby.jpg"},

            new MultiChoiceQuestion{Question="What colour do we wear at Rosh Hashanah?",
                                    A="white",
                                    B="cream",
                                    C="pale blue",
                                    D="dark blue",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Gymnastics.jpg"},

            new MultiChoiceQuestion{Question="Traditionally, many people dress in what special way on Yom Kippur?",
                                    A="In all white or light colors, to symbolize purity ",
                                    B="In all black or dark colors, to symbolize sin ",
                                    C="In brand new clothes, to symbolize a fresh start ",
                                    D="In leather, for no apparent reason ",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Haru.jpg"},


            new MultiChoiceQuestion{Question="When reciting the list of sins, called the Viddui, it is customary for people to",
                                    A="Remain seated",
                                    B="To stand and stomp after each sin is read",
                                    C="Bow after each sin is read",
                                    D="To stand and beat their chests after each sin is read",
                                    Answer ="D",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Mako.jpg"},

            new MultiChoiceQuestion{Question="4x4+4x4+4-4x4=",
                                    A="4",
                                    B="20",
                                    C="14",
                                    D="36",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Math.jpg"},

            new MultiChoiceQuestion{Question="During Sukkot, one is supposed to welcome Ushpizin into his or her Sukkah. What the heck are Ushpizin?",
                                    A="Ants and other insects",
                                    B="Spiritual guests/ ancestors",
                                    C="Rabbis in your community",
                                    D="Pets",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Menions.jpg"},

            new MultiChoiceQuestion{Question="On the afternoon of the first day of Rosh Hashanah, customary to walk to a body of flowing water, say a special prayer, and symbolically empty our pockets into the river, casting off our sins. What is this custom called?",
                                    A="Neila",
                                    B="Repentance",
                                    C="Tashlich",
                                    D="Kol Nidre",
                                    Answer ="C",
                                    QuestionType = QUESTION_TYPE.Poop,
                                    ImageTag="MichaelPhelps.jpg"},

            new MultiChoiceQuestion{Question="In which Torah passage is the shofar alluded to?",
                                    A="When God remembers Sarah and she becomes pregnant with Isaac",
                                    B="The binding of Isaac",
                                    C="When Isaac meets Rebecca",
                                    D="When Isaac’s two sons are born, Jacob and Esav",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Gold,
                                    ImageTag="Panda.jpg"},

            new MultiChoiceQuestion{Question="Which animal can a shofar NOT be made of?",
                                    A="Ibex",
                                    B="Ram",
                                    C="Bull",
                                    D="Gazelle",
                                    Answer ="C",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Piano.jpg"},

            new MultiChoiceQuestion{Question="What is the name of the Rosh Hashanah parayer book?",
                                    A="Machzor",
                                    B="Sidur",
                                    C="Haggadah",
                                    D="Shofar",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="PrayerBook.jpg"},

            new MultiChoiceQuestion{Question="We eat pomegrante on Rosh Hashanah because:",
                                    A="We want our pockets to be filled with money like the pomegranate is filled with seeds",
                                    B="We want our mind to be full of Torah like the pomegranate is filled with seeds",
                                    C="We want to be filled with mitzvot like the pomegranate is filled with seeds",
                                    D="We want to be filled with happiness like the pomegranate is filled with seeds",
                                    Answer ="C",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Rimon.jpg"},

            new MultiChoiceQuestion{Question="What special type of challah(s) is traditionally eaten during Rosh Hashanah?", 
                                    A="Two challahs that are identical in length, one for each day",
                                    B="Challah with chocolate chips, to symbolize the sweetness of life",
                                    C="Round challah, to symbolize the eternal cycle of life",
                                    D="A challah in the shape of a book, to symbolize God’s books of life and death",
                                    Answer ="C",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="RoundChalla.jpg"},


            new MultiChoiceQuestion{Question="Which group of foods is customary to eat on Rosh Hashanah?",
                                    A="Pomegrante, carrots, dates, head of a fish",
                                    B="Apples, pears, peaches, greaps",
                                    C="Pancakes, jelly doughnuts, turkey",
                                    D="Pomegrante, dates, peanutes, a large radish",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Seder.jpg"},

            new MultiChoiceQuestion{Question="On which first and second day of which Hebrew month is Rosh Hashanah celebrated?",
                                    A="Sivan",
                                    B="Tishrei",
                                    C="Elul",
                                    D="Av",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="ShanahTova.jpg"},

            new MultiChoiceQuestion{Question="On Rosh Hashanah, everyone is judged by Hashem based on his/her actions during the previous year. God waits until Yom Kippur to seal the book for the year. What three things can a person do to change their judgment for the better?",
                                    A="Prayer, charity and drinking 4 cups of wine",
                                    B="Prayer, charity and fasting",
                                    C="Repentance, prayer and the blessing of the Kohen",
                                    D="Repentance, prayer and charity",
                                    Answer ="D",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="SimhatTorah.jpg"},

            new MultiChoiceQuestion{Question="The maximum area of a sukkah is ...",
                                    A="about 20 x 20 feet, large enough for a family",
                                    B="the size of a typical back yard",
                                    C="not larger than one's home",
                                    D="as large as you want: there is no maximum area",
                                    Answer ="D",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Surf.jpg"},

            new MultiChoiceQuestion{Question="What do some scholars believe Shemini Atzeret was devoted to in Temple times?",
                                    A="Cleaning up the Temple after the previous holiday",
                                    B="The ritual cleansing of the altar",
                                    C="Religious sacrifices ",
                                    D="Remembering the giving of the Torah at Mount Sinai",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Temple.jpg"},

            new MultiChoiceQuestion{Question="What is the name of the nine short fast blasts we sound with the shofar?",
                                    A="Shevarim",
                                    B="Tekia Gedolah",
                                    C="Tekia",
                                    D="Terua",
                                    Answer ="D",
                                    QuestionType = QUESTION_TYPE.Gold,
                                    ImageTag="Terua.jpg"},

            new MultiChoiceQuestion{Question="How many hours is the Yom Kippur fast?",
                                    A="27 hours",
                                    B="25 hours",
                                    C="23 hours",
                                    D="24 hours",
                                    Answer ="B",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="WesternWall.jpg"},

            new MultiChoiceQuestion{Question="What is the final prayer of Yom Kippur called?",
                                    A="Maariv",
                                    B="Unesaneh Tokef",
                                    C="Kol Nidre",
                                    D="Neilah",
                                    Answer ="D",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="YomKippurAhead.jpg"},


            new MultiChoiceQuestion{Question="Why do we avoid wearing leather shoes on Yom Kippur?",
                                    A="Leather represented luxury in aincient times",
                                    B="It is written in the Torah",
                                    C="Wearing sneakers ismore comfertable when fasting",
                                    D="Leather shoes is made from animal suffering",
                                    Answer ="A",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Yosemite.jpg"},

            new MultiChoiceQuestion{Question="What is the name of the prayer recited before the dancing begins on Simhat Torah?",
                                    A="Akdamut",
                                    B="Hoshana",
                                    C="Atta Horeita",
                                    D="Dayenu",
                                    Answer ="C",
                                    QuestionType = QUESTION_TYPE.Gold,
                                    ImageTag="YouThinkYouCanDance.jpg"},

            new MultiChoiceQuestion{Question="Over which fruit to we recite: May it be your will...that our foes be consumed",
                                    A="Head of a fish",
                                    B="Apple",
                                    C="Rimon",
                                    D="Date",
                                    Answer ="D",
                                    QuestionType = QUESTION_TYPE.Regular,
                                    ImageTag="Zuko.jpg"},
        
        };
        */
        public QuestionCenter(int id)
        {
            _id = id;
            if (!System.IO.File.Exists(QUESTIONS_FILE_NAME))
            {
                SaveQuestions();
            }

        }
        private void SaveQuestions()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MultiChoiceQuestion[]));
            System.IO.FileStream file = System.IO.File.Create(QUESTIONS_FILE_NAME);
            serializer.Serialize(file, _questions);
            file.Close();
        }
        public void LoadConfiguration()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MultiChoiceQuestion[]));
            System.IO.FileStream file = System.IO.File.OpenRead(QUESTIONS_FILE_NAME);
            _questions = (MultiChoiceQuestion[])serializer.Deserialize(file);
            file.Close();
        }

        public string GetImageName()
        {
            return _questions[_id].ImageTag;
        }
        public MultiChoiceQuestion GetQuestion()
        {
            return _questions[_id];
        }
        public string GetAnswer()
        {
            return _questions[_id].Answer;
        }


        internal QUESTION_TYPE IsGoldenQuestion()
        {
            return _questions[_id].QuestionType;
        }

        internal string GetPoopImage()
        {
            return "Poop.jpg";
        }
    }
}
