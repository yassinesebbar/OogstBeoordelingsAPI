namespace OogstBeoordelingsAPI.Dto.AssessorDtos
{
    public class OrderedHarvestListDto
    {
        public List<GetHarvestAssessorDto> HarvestList { get; set; }
        public string NameHarvester { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }

        public OrderedHarvestListDto()
        {
            HarvestList = new List<GetHarvestAssessorDto>();
        }

        public void AddHarvestToList(GetHarvestAssessorDto harvestDto)
        {
            HarvestList.Add(harvestDto);
        }
    }
}
