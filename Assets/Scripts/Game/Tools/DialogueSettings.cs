using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Game.Tools
{
    [XmlRoot("dialogue")]
    public class DialogueSettings
    {
        [XmlElement("node")] public Node[] Nodes;

        public static DialogueSettings Load(TextAsset xml){
            XmlSerializer serializer = new XmlSerializer(typeof(DialogueSettings));
            StringReader reader = new StringReader(xml.text);
            DialogueSettings settings = serializer.Deserialize(reader) as DialogueSettings;
            return settings;
        }
    }

    [Serializable]
    public class Node
    {
        [XmlAttribute("name")] public string name;
        [XmlAttribute("text")] public string text;
        [XmlAttribute("new_background")] public string newBackground;
        [XmlAttribute("hide_text")] public string hideText;

        [XmlArray("answers")] 
        [XmlArrayItem("answer")]
        public Answer[] answers;
    }

    [Serializable]
    public class Answer
    {
        [XmlAttribute("id")] public int id;

        [XmlAttribute("text")] public string text;

        [XmlAttribute("to_node")] public string toNode;
    }
}


