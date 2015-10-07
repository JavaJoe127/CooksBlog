// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryMap.cs" company="HotR">
//   2015
// </copyright>
// <summary>
//   The Category Mapping for blog database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CooksBlog.Mappings
{
    using FluentNHibernate.Mapping;
    using Objects;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryMap"/> class.
    /// </summary>
    public class CategoryMap: ClassMap<Category>
    {
        public CategoryMap()
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

            HasMany(x => x.Posts)
                .Inverse()
                .Cascade.All()
                .KeyColumn("Category");
        }
    }
}