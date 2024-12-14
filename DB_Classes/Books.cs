using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SUBD_books_project.DB_Classes
{
    public partial class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int IdPublishingHouse { get; set; }

        public virtual PublishingHouses IdPublishingHouseNavigation { get; set; }
    }
}
