/*
 * REST API Documentation for the MOTI Hired Equipment Tracking System (HETS) Application
 *
 * The Hired Equipment Program is for owners/operators who have a dump truck, bulldozer, backhoe or  other piece of equipment they want to hire out to the transportation ministry for day labour and  emergency projects.  The Hired Equipment Program distributes available work to local equipment owners. The program is  based on seniority and is designed to deliver work to registered users fairly and efficiently  through the development of local area call-out lists. 
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HETSAPI.Models;

namespace HETSAPI.Models
{
    /// <summary>
    /// 
    /// </summary>

    public partial class ImportProgress : AuditableEntity, IEquatable<ImportProgress>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public ImportProgress()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportProgress" /> class.
        /// </summary>
        /// <param name="Id">A system generated unique identifier for the ImportProgress record (required).</param>
        /// <param name="JobIdentifier">Job identifier (required).</param>
        /// <param name="Stage">Name of the current stage (required).</param>
        /// <param name="Position">Position within the current stage (required).</param>
        public ImportProgress(int Id, string JobIdentifier, string Stage, int Position)
        {   
            this.Id = Id;
            this.JobIdentifier = JobIdentifier;
            this.Stage = Stage;
            this.Position = Position;



        }

        /// <summary>
        /// A system generated unique identifier for the ImportProgress record
        /// </summary>
        /// <value>A system generated unique identifier for the ImportProgress record</value>
        [MetaDataExtension (Description = "A system generated unique identifier for the ImportProgress record")]
        public int Id { get; set; }
        
        /// <summary>
        /// Job identifier
        /// </summary>
        /// <value>Job identifier</value>
        [MetaDataExtension (Description = "Job identifier")]
        public string JobIdentifier { get; set; }
        
        /// <summary>
        /// Name of the current stage
        /// </summary>
        /// <value>Name of the current stage</value>
        [MetaDataExtension (Description = "Name of the current stage")]
        public string Stage { get; set; }
        
        /// <summary>
        /// Position within the current stage
        /// </summary>
        /// <value>Position within the current stage</value>
        [MetaDataExtension (Description = "Position within the current stage")]
        public int Position { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ImportProgress {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  JobIdentifier: ").Append(JobIdentifier).Append("\n");
            sb.Append("  Stage: ").Append(Stage).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }
            if (obj.GetType() != GetType()) { return false; }
            return Equals((ImportProgress)obj);
        }

        /// <summary>
        /// Returns true if ImportProgress instances are equal
        /// </summary>
        /// <param name="other">Instance of ImportProgress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ImportProgress other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.JobIdentifier == other.JobIdentifier ||
                    this.JobIdentifier != null &&
                    this.JobIdentifier.Equals(other.JobIdentifier)
                ) &&                 
                (
                    this.Stage == other.Stage ||
                    this.Stage != null &&
                    this.Stage.Equals(other.Stage)
                ) &&                 
                (
                    this.Position == other.Position ||
                    this.Position.Equals(other.Position)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.JobIdentifier != null)
                {
                    hash = hash * 59 + this.JobIdentifier.GetHashCode();
                }                
                                if (this.Stage != null)
                {
                    hash = hash * 59 + this.Stage.GetHashCode();
                }                
                                                   
                hash = hash * 59 + this.Position.GetHashCode();
                return hash;
            }
        }

        #region Operators
        
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ImportProgress left, ImportProgress right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ImportProgress left, ImportProgress right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
