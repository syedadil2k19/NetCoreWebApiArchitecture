using System;
using System.ComponentModel.DataAnnotations;

namespace Web.API.Domain.Entity
{
    /// <summary>Serves as base for all data models.</summary>
    public class BaseEntity
    {
        /// <summary>Represents the primary key for data models derived from <see cref="BaseEntity"/></summary>
        /// <value>Property <c>Id</c> represents an entity's primary key</value>
        [Key]
        public int Id { get; set; }
        /// <summary>Denotes the date and time of creation of the entity.</summary>
        /// <value>Timestamp of creation of the entity.</value>
        /// <remarks>Value must be set manually using approaches like auditing or triggers etc.</remarks>
        public DateTime Created { get; set; }
        /// <summary>Denotes the date and time of the last modification to the entity.</summary>
        /// <value>Timestamp of last updation of the entity.</value>
        /// <remarks>Value must be set manually using approaches like auditing or triggers etc.</remarks>
        public DateTime Modified { get; set; }
    }
}
