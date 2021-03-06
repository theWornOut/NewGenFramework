﻿
using System.Collections.Generic;
using System.Linq;
using BayiPuan.Business.Abstract;
using NewGenFramework.Core.Aspects.Postsharp.CacheAspects;
using NewGenFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using BayiPuan.DataAccess.Abstract;
using BayiPuan.Entities.Concrete;
using NewGenFramework.Core.CrossCuttingConcerns.Transaction;

namespace BayiPuan.Business.Concrete.Managers
{
    public class UnitTypeManager : ManagerBase, IUnitTypeService
    {
        private readonly IUnitTypeDal _unitTypeDal;

        public UnitTypeManager(IUnitTypeDal unitTypeDal)
        {
            _unitTypeDal = unitTypeDal;
        }
        
         // [LogAspect(typeof(DatabaseLogger))]
        [CacheAspect(typeof(MemoryCacheManager))]
        // [PerformanceCounterAspect(1)]      
        public List<UnitType> GetAll()
        {
            return _unitTypeDal.GetList();
        }

        public UnitType GetById(int unitTypeId)
        {
            return _unitTypeDal.Get(u => u.UnitTypeId == unitTypeId);
        }      

        //[FluentValidationAspect(typeof(UnitTypeValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public UnitType Add(UnitType unitType)
        {
            return _unitTypeDal.Add(unitType);
        }
        //[FluentValidationAspect(typeof(UnitTypeValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(UnitType unitType)
        {
              _unitTypeDal.Update(unitType);
        }

        public void Delete(UnitType unitType)
        {
            _unitTypeDal.Delete(unitType);
        }    

        public List<UnitType> GetByUnitType(int unitTypeId)
        {
            return _unitTypeDal.GetList(filter: t => t.UnitTypeId == unitTypeId).ToList();
        }
    }
}
