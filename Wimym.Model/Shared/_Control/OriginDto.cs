namespace Wimym.Model.Shared._Control
{
    using System.Collections.Generic;
    using Wimym.Model.Shared._General;

    public class OriginDto
    {
        public int OriginId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Simbol { get; set; }

        public List<AccountTypeDto> AccountTypes { get; set; }

        public List<OperationDto> Operations { get; set; }
    }

    public class OriginGetFilter
    {
        public int? OriginId { get; set; }
    }

    public class OriginListFilter
    {
        public int? OriginId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }

    public class OriginList
    {
       // public int OriginId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Simbol { get; set; }

        public List<AccountTypeDto> AccountTypes { get; set; }

        public List<OperationDto> Operations { get; set; }
    }
}
