// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagMap.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Tag Mapping for blog database
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Mappings
{
    using FluentNHibernate.Mapping;
    using Objects;

    /// <summary>
    /// Initializes a new instance of the <see cref="TagMap"/> class
    /// </summary>
    public class TagMap: ClassMap<Tag>
    {
        public TagMap()
        {
            Id(x => x.Id);

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(200)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(200);

            HasManyToMany(x => x.Posts)
                .Cascade.All()
                .Table("PostTagMap");
        }
    }
}