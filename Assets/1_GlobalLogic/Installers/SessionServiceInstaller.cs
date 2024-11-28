using Zenject;

public class SessionServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LevelArrayDataManager>().AsSingle();
        Container.Bind<CurrentLevelDataManager>().AsSingle();

        Container.Bind<SessionScreenService>().AsSingle();
        Container.Bind<LevelService>().AsSingle();
        Container.Bind<ShootingService>().AsSingle();
        Container.Bind<UnitViewService>().AsSingle();
        Container.Bind<FinishPanelService>().AsSingle();
        Container.Bind<LosePanelService>().AsSingle();
    }
}
/* EXAMPLE
 
   //DataManagers :
        //L1
        Container.Bind<ItemPoolDataManager>().AsSingle();
        Container.Bind<CoinDataManager>().AsSingle();
        Container.Bind<LevelDataManager>().AsSingle();
        Container.Bind<DailyGiftDataManager>().AsSingle();
        //L2
        Container.Bind<UpgradeDataManager>().AsSingle();
        Container.Bind<ClickMineDataManager>().AsSingle();
        Container.Bind<AutoMineDataManager>().AsSingle();
        //L3
        Container.Bind<TaskDataManager>().AsSingle();
        
        //Services :
        //L1
        Container.Bind<ShopPanelService>().AsSingle();
        Container.Bind<SessionScreenService>().AsSingle();
        Container.Bind<ShopItemPoolService>().AsSingle();
        Container.Bind<ClickPanelService>().AsSingle();
        Container.Bind<CoinPanelService>().AsSingle();
        Container.Bind<LevelPanelService>().AsSingle();
        Container.Bind<ClickMinePanelService>().AsSingle();
        Container.Bind<AutoMinePanelService>().AsSingle();
        Container.Bind<TaskPanelService>().AsSingle();
        Container.Bind<CoinGiftService>().AsSingle();
        Container.Bind<GemGiftService>().AsSingle();
        Container.Bind<TakeGiftScreenService>().AsSingle();
        //L2        
        Container.Bind<GiftServiceManager>().AsSingle();
        //L3
        Container.Bind<DailyGiftScreenService>().AsSingle();
*/