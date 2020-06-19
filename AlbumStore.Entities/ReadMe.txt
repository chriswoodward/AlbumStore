
Entity Framework Core expects a single public Constructor to enable Context Pooling

When using the EF Core Power Tools, the auto code generator creates a parameterless public constructor

This results in :- 
"The DbContext of type '< ... >' cannot be pooled because it does not have a single public constructor accepting a single parameter of type DbContextOptions"

So to get round this, one option is to make the parameterless public constructor "private" in the DbContext class

However, be aware that using EF Core Power Tools will overwrite this each time the DbContext class re-generated ...