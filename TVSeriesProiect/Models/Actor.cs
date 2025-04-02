using SQLite;


namespace TVSeriesProiect.Models
{
    [Table("actor")]
    public class Actor
    {
        [Column("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("numberOfTVSeriesInTop")]
        public int NumberOfTVSeriesInTop { get; set; }
        public Actor()
        {

        }
        public Actor(string name)
        {
            this.Name = name;
            this.NumberOfTVSeriesInTop = 1;
        }
    }

}
