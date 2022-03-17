using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Core.Entities
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        private byte[] Image { get; set; }
    }
}