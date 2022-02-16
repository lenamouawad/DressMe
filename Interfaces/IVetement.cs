using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace DressMe.Interfaces
{
    public enum Types
    {
        sport,
        decontracte,
        habille,
        soiree,
        exterieur
    }

    public enum Motifs
    {
        pasDeMotifs,
        fleuri,
        rayures,
        imprime,
        carreaux,
        paillettes,
        marbre,
        geometrique,
        strass,
        perles,
        chevrons,
        texte
    }

    public enum Matiere
    {
        denim,
        maille,
        coton,
        lin,
        fourrure,
        laine,
        satin,
        soie,
        cuir,
        cachemire,
        velours,
        dentelle,
        tricot,
        synthetique,
        polyester,
        autre
    }

    public enum Couleur
    {
        jaune,
        rouge,
        bleu,
        orange,
        magenta,
        marron,
        gris,
        beige,
        kaki,
        violet,
        rose,
        turquoise,
        vert,
        blanc,
        noir,
        bordeaux
    }

    public interface IVetement
    {
        [JsonProperty("Couleur", ItemConverterType = typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public List<Couleur> Couleur { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Matiere Matiere { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Motifs Motifs { get; set; }
        public string ImgUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Types Type { get; set; }
    }
}
