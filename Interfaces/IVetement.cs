using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DressMe.Interfaces
{
   /* public enum Categorie
    {
        robe,
        pull,
        sweat,
        tshirt,
        top,
        chemise,
        blouse,
        gilet,
        veste,
        blazer,
        manteau,
        doudoune,
        trench,
        pantalon,
        jeans,
        shorts,
        jupe
    }*/

    public enum Types
    {
        sport,
        maison,
        habille,
        decontracte
    }

    public enum Motifs
    { 
        pasDeMotifs, 
        rayure, 
        imprime, 
        carreaux, 
        paillettes, 
        marbre,
        geometrique, 
        strass, 
        perles, 
        chevrons }

    public enum Matiere { 
        denim, 
        maille, 
        coton, 
        lin, 
        fourrure, 
        laine, 
        synthetique, 
        satin, 
        cachemire, 
        velours, 
        dentelle, 
        tricot, 
        sequins }

    public enum Couleur { 
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
        noir}

    public interface IVetement
    {
        [JsonConverter(typeof(StringEnumConverter))]
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
        //public Categorie Categorie { get; set; }
    }
}
