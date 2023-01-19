using OogstBeoordelingsAPI.Dto.AssessorDtos;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Services
{
    public class HarvestService : IHarvestService
    {

    private readonly IHarvestRepository _harvestRepository;

        public HarvestService(IHarvestRepository harvestRepository)
        {
            _harvestRepository = harvestRepository;
        }

        public string CreateHarvest(Harvest harvest)
        {
            harvest.Uid = GenerateUniqueID(harvest.GrowerId);
            _harvestRepository.Save(harvest);
            return harvest.Id;
        }

        private int GenerateUniqueID(int growerId)
        {
            /*> db.getLastInsertedDocument.find({ }).sort({ _id: -1}).limit(1);*/
            Harvest harvest =  _harvestRepository.GetLastInsertedCurrentYearByGrower(growerId);

            if (harvest == null)
            {
                return 1;
            }
            return harvest.Uid + 1;
        }

        public async Task<List<Harvest>> GetAllClosedByGrower(User user) => await _harvestRepository.GetAllByGrower(user.Id, HarvestStatus.Closed);
        
        public async Task<List<Harvest>> GetAllNotClosedByGrower(User user)
        {

           List<Harvest> FinalList = new List<Harvest>();
           List<Harvest> harvestPending = await _harvestRepository.GetAllByGrower(user.Id, HarvestStatus.Pending);
           List<Harvest> harvestToBeReviewed = await _harvestRepository.GetAllByGrower(user.Id, HarvestStatus.ToBeReviewed);
           List<Harvest> harvestToBeSold = await _harvestRepository.GetAllByGrower(user.Id, HarvestStatus.ToBeSold);

            FinalList.AddRange(harvestPending);
            FinalList.AddRange(harvestToBeReviewed);
            FinalList.AddRange(harvestToBeSold);

            return FinalList;
        }

        public async Task<Harvest> GetHarvestById(string Id) => await _harvestRepository.GetById(Id);
        public async Task<Harvest> GetHarvestById(string harvestId, int growerId) => await _harvestRepository.GetById(harvestId, growerId);

        public async Task<Boolean> LinkAssessorToHarvest(List<string> ListHarvestIds, User user)
        {
            foreach (string harvestId in ListHarvestIds)
            {
                Harvest harvest = await _harvestRepository.GetById(harvestId);

                if (harvest.Status == HarvestStatus.Pending)
                {
                    harvest.Status = HarvestStatus.ToBeReviewed;
                    harvest.ReviewerId = user.Id;
                    harvest.ReviewerName = user.FirstName + ' ' + user.LastName;
                    await _harvestRepository.UpdateOne(harvest);

                }
            }

            return true;
        }

        public async Task<Boolean> SubmitReview(Review NewReview, User assessor)
        {
            Harvest harvest = await _harvestRepository.GetByAssessor(NewReview.Id, assessor.Id);

            if (harvest != null)
            {
                NewReview.ReviewerId = assessor.Id;
                NewReview.ReviewerName = assessor.FirstName + " " + assessor.LastName;
                harvest.Status = HarvestStatus.ToBeSold;
                harvest.Review = NewReview;

                await _harvestRepository.UpdateOne(harvest);

                return true;
            }

            return false;
        }

        public async Task<List<Harvest>> GetAllPending() => await _harvestRepository.GetAllHarvestByStatus(HarvestStatus.Pending);
        public async Task<List<Harvest>> GetClosedByAssessor(User assessor) => await _harvestRepository.GetAllByAssessor(assessor.Id, HarvestStatus.Closed);
        public async Task<List<Harvest>> GetToBeReviewdByAssessor(User assessor) => await _harvestRepository.GetAllByAssessor(assessor.Id, HarvestStatus.ToBeReviewed);


        public List<OrderedHarvestListDto> OrderToHarvestListDto(List<Harvest> harvestList)
        {

            List<OrderedHarvestListDto> OrderedHarvestListDto = new List<OrderedHarvestListDto>();

            IEnumerable<List<Harvest>> HarvestListDto = harvestList.GroupBy(i => i.GrowerId).Select(group => group.ToList()).ToList();

            foreach (List<Harvest> orderedHarvestListIterator in HarvestListDto)
            {
                Harvest harvest = orderedHarvestListIterator.First();
                if (OrderedHarvestListDto.Find(o => o.UserId == harvest.GrowerId) == null)
                {
                    OrderedHarvestListDto orderedHarvestDto = new OrderedHarvestListDto() {UserId = harvest.GrowerId, NameHarvester = harvest.GrowerName, Address = harvest.GrowerName};
                    OrderedHarvestListDto.Add(orderedHarvestDto);
                }

                OrderedHarvestListDto orderedHarvestListDtos = OrderedHarvestListDto.Find(o => o.UserId == harvest.GrowerId);

                foreach (Harvest harvestIterator in orderedHarvestListIterator)
                {
                    GetHarvestAssessorDto getHarvestDto = new GetHarvestAssessorDto(harvestIterator, null);
                    orderedHarvestListDtos.AddHarvestToList(getHarvestDto);
                }
            }

            return OrderedHarvestListDto;
        }

        public async Task<Harvest> GetHarvestByIdAssessor(string harvestId, int assessorId)
        {
            return await _harvestRepository.GetByAssessor(harvestId, assessorId);
        }
    }
}
