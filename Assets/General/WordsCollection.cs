
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SubtituableWord
{
    public int originalIndex;
    public string originalWord;
    public WordType type;
}

public enum WordType { adjective, noun, verb}


public class WordsCollection
{
     public string[] BadAdjectives = new string[] {"chad","snail","boiled","rolling","sweaty","toilet","crunchy","moldy","sad","smoking","swine","sick","loud","idiotic","cataclysmic",
                                        "wacky","mindless","foolish","salty","stupid","sluggish","miserable","cringe","dull","zombified","awkward","grotesque","OG","absurd",
                                        "drunk","sour","bitter","freaky","chicken","screamy","dorktastic","jittery","kooky","stonks","smelly",};

    public string[] BadVerbs = new string[] {"despised","masturbated","polluted","infected","spoiled","hated","stained","smacked","ruined","tickled","trolled","poked","sabotaged",
                                                "robbed","spat","gambled","struck","destroyed","poisoned","exploited","drank","burned","mummified","flexed","hyped","jinxed"};

    public string[] BadVNouns = new string[] {"bruh","meme","noob","simp","snot","gorilla","lobster","schlimazel","orangutan","jellyfizzle","wart","goo","fart","noodlehead",
                                    "muffinbrain","cupcake","dunghead","dimwit","goober","wimp","dong","fool","cretin","picklehand","schlong","buffoon","numbskull","cuckoo",
                                    "tofu","smoothie","waffle","pukestorm","urine","blockhead","vomit","mouth","teeth","picklenose","armpit","gravy","radish","cockroach",
                                    "slimeball","vomit","garbage","dirtbag","factory","stench","bullspit","dogsneeze","vermin","catpiss","bastard","snore","deadbeat","dork",
                                    "saliva","freak","gasbag","jerk","scumbag","blister","earwax","creme","crybaby","dimple","drool","swag","jibber-jabber",};

    //kid's story
    public string story1 = "In the [adjective,quaint] town of Veggiesdorf, the [noun,air] was [verb,filled] with the [adjective,sweet] scent of [noun,earth] and [noun,spring]. [Noun,Farmer] Joe, renowned for his [adjective,green] [noun,thumb], started a [noun,horticulture] experiment. With his [adjective, vibrant] [noun,smile] and [adjective,unwavering] [noun,determination], he [verb,cultivated] a [adjective,colorful] [noun, carrot] of [adjective,crimson], [adjective,blue], and [adjective,gold]. As the [noun,sun] kissed the [adjective, fertile] [noun, soil], Joe's [noun,garden] flourished with a [adjective,wondrous] crunchy [noun,delight]. Locals [verb,marveled] at the [noun,harvest], and [noun,Veggiesdorf] soon became known for its [adjective,diverse] [noun, carrot] [noun,bounty]. Farmer Joe's [noun,success] not only [verb,filled] the [noun,town's_plates] but also [verb,sowed] a [noun,sense] of [noun,community] rooted in the [noun,love] for the [adjective,humble] [noun,carrot].";

    //TED talk
    public string story2 = "Ladies and gentlemen, in the pursuit of [noun,personal_growth], let us embrace the [adjective,transformative] [noun,power]. Each [noun,challenge] or [noun,triumph] is a [noun, stepping stone] toward our [adjective,highest] [noun,potential]. By [verb,cultivating] [noun,resilience], [noun, self-awareness], and a [noun, hunger] for [noun, knowledge], we [verb, unlock] the [noun, doors] to our own [noun,evolution]. It's not just about [verb,reaching] [noun,goals]; it's about [verb,becoming] the [noun,person] capable of [verb, achieving] them. [Verb, Embrace] [noun,discomfort], [verb,learn] from [noun,failures], and [verb,savor] [noun, victories]. [Noun,Personal_growth] is a [adjective,perpetual] [noun,journey], not a [noun,destination]. Together, let's [verb,foster] a [noun,culture] of [adjective,continuous] [noun,improvement], [verb,empowering] ourselves and others to [verb,thrive] in a world [verb,defined] by [noun,change].";

    //80’s biker movie commercial
    public string story3 = "In the neon-soaked city, I ruled the road, a [noun, lone wolf] on my [noun, chrome steed]. I chased the [noun, adrenaline] high of [adjective, wide] endless roads. The [noun, roar] of my [noun, engine] echoed [noun, rebellion], a [noun, symphony] of [noun, power]. [noun, Dust] trailed behind as I [verb, weaved] through the [noun, concrete jungle], an [noun, outlaw] in the [noun, midnight haze]. The city's [noun, heartbeat] synchronized with the [adjective, rhythmic] [noun, growl] of my [noun, bike], as an [adjective, unspoken] [noun, language] of [noun, freedom]. Each [noun, curve], each [noun, twist] of the [noun, throttle], was a [noun, dance] with [noun, danger]. I was more than a [noun, rider]; I was a [adjective, living] [noun, legend]. Etched my [noun, saga] into the [noun, history] of the [noun, road].";

    //Northener speech
    public string story4 = "In the frost-kissed heart of the North, I stand[adjective, resolute] as a[noun, sentinel] of the land.The bitter winds may howl, but my [noun, armor] shields me, [adjective, steadfast] against the threats that lurk in the shadows. I've faced [noun, dragon]s that darken the sky with their ominous wings, and [verb, battled] through [adjective, ancient] crypts [verb, haunted] by the echoes of the past. As a [noun, guardian] I [verb, pledge] to defend the [noun, realm] with [noun, unyielding] determination.";

    //Frustrated Customer
    public string story5 = "Ladies and gentlemen, I stand before you today, a [adjective, frustrated] customer, seeking a moment of your attention. I've navigated the labyrinth of customer service, hoping for a resolution that has [verb, eluded] me so far. The [noun, frustration] is real, my friends, but so is the [noun, determination]. We deserve more than [adjective, automated] responses and [adjective, endless] hold music. Our [noun, voice]s matter, our [noun, concerns] are valid. It's time for a [noun, change]! Let's transform [noun, frustration] into [noun, inspiration], turning this challenge into an [noun, opportunity].";

    //Politician
    public string story6 = "Fellow [noun, citizens], I stand before you not as a polished [noun, politician], but as a [noun, neighbor] who cares deeply about our [noun, community]. Today, I want to be [adjective, honest] with you. Our [noun, town] faces [noun, challenges], big and small. But challenges are just [noun, opportunities] in disguise. Let's be [adjective, real] about what matters – our [noun, schools], our [noun, roads], and our [noun, safety]. It's time to [verb, invest] in the [noun, foundations] that make us [adjective, strong]. I [verb, promise] to [verb, listen], to [verb, learn], and to [verb, work] hard for each one of you. Together, let's build a [noun, future] we can all be [adjective, proud] of – a [noun, community] where every [noun, voice] is [verb, heard], and every [noun, person] [verb, matters]. Thank you for your [noun, trust] and your [noun, commitment] to our [adjective, shared] journey.";


    public int ProcessText(int storyIdx, out List<SubtituableWord> subtituableWords)
    {
        string text = storyIdx switch
        {
            0 => story1,
            1 => story2,
            2 => story3,
            3 => story4,
            4 => story5,
            5 => story6,
            _ => throw new System.Exception(storyIdx.ToString()),
        };

        subtituableWords = new List<SubtituableWord>();
        List<int> bracketOP = new List<int>();
        List<int> bracketED = new List<int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '[')
            {
                bracketOP.Add(i);
            }

            if (text[i] == ']')
            {
                bracketED.Add(i);
            }
        }

        for (int i = 0; i < bracketED.Count; ++i)
        {
            string ss = text.Substring(bracketOP[i], bracketED[i] - bracketOP[i]);
            string[] sub = ss.Split(",");
            SubtituableWord sw = new SubtituableWord();
            sw.originalWord = sub[1];
            switch (sub[0].ToLower())
            {
                case "adjective":
                    sw.type = WordType.adjective; break;
                case "noun":
                    sw.type = WordType.noun; break;
                case "verb":
                    sw.type = WordType.verb; break;
                default:
                    break;
            }
            subtituableWords.Add(sw);
        }
        return subtituableWords.Count;
    }
}
