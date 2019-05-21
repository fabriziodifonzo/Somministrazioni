// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Somministrazioni.Data.Models.DBEntities
{

    // DEMO_CUSTOMERS
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public class DemoCustomerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DemoCustomer>
    {
        public DemoCustomerConfiguration()
            : this("SOMMINISTRAZIONE")
        {
        }

        public DemoCustomerConfiguration(string schema)
        {
            ToTable("DEMO_CUSTOMERS", schema);
            HasKey(x => x.CustomerId);

            Property(x => x.CustomerId).HasColumnName(@"CUSTOMER_ID").HasColumnType("number").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CustFirstName).HasColumnName(@"CUST_FIRST_NAME").HasColumnType("varchar2").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.CustLastName).HasColumnName(@"CUST_LAST_NAME").HasColumnType("varchar2").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.CustStreetAddress1).HasColumnName(@"CUST_STREET_ADDRESS1").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(60);
            Property(x => x.CustStreetAddress2).HasColumnName(@"CUST_STREET_ADDRESS2").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(60);
            Property(x => x.CustCity).HasColumnName(@"CUST_CITY").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.CustState).HasColumnName(@"CUST_STATE").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(2);
            Property(x => x.CustPostalCode).HasColumnName(@"CUST_POSTAL_CODE").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.PhoneNumber1).HasColumnName(@"PHONE_NUMBER1").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(25);
            Property(x => x.PhoneNumber2).HasColumnName(@"PHONE_NUMBER2").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(25);
            Property(x => x.CreditLimit).HasColumnName(@"CREDIT_LIMIT").HasColumnType("number").IsOptional().HasPrecision(9,2);
            Property(x => x.CustEmail).HasColumnName(@"CUST_EMAIL").HasColumnType("varchar2").IsOptional().IsUnicode(false).HasMaxLength(30);
        }
    }

}
// </auto-generated>
