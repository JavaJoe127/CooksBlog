// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostMap.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Post Mapping for blog database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Mappings
{
    using FluentNHibernate.Mapping;
    using Objects;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostMap"/> class.
    /// </summary>
    public class PostMap: ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id);

            Map(x => x.Title)
                .Length(500)
                .Not.Nullable();

            Map(x => x.ShortDescription)
                .Column("short_description")
                .Length(1000)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Meta)
                .Length(1000)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(200)
                .Not.Nullable();

            Map(x => x.Published)
                .Column("publish_date")
                .Not.Nullable();

            Map(x => x.PostedOn)
                .Column("posted_date")
                .Not.Nullable();

            Map(x => x.Modified);

            References(x => x.Category)
                .Column("Category")
                .Not.Nullable();

            HasManyToMany(x => x.Tags)
                .Table("PostTagMap");
        }
    }
}
