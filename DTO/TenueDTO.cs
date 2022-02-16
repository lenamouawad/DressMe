using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DressMe.DTO
{
    public class TenueDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string hautImgUrl { get; set; }
        public string vesteImgUrl { get; set; }

        public string basImgUrl { get; set; }

        public string chaussureImgUrl { get; set; }

        public TenueDTO()
        {
        }

        public TenueDTO(string id, string hautImgUrl, string vesteImgUrl, string basImgUrl, string chaussureImgUrl)
        {
            this.id = id;
            this.hautImgUrl = hautImgUrl;
            this.vesteImgUrl = vesteImgUrl;
            this.basImgUrl = basImgUrl;
            this.chaussureImgUrl = chaussureImgUrl;
        }

    }
}
