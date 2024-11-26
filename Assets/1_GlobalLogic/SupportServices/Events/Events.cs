public class OnFocus { public bool status; }
public class OnMarkerAwake { public IMarker Marker; }
public class OnChangeAudioValue { }
public class OnFinishSession { }
public class OnLoseSession { }
public class OnNextLevel { }
public class OnRestartLevel { }
public class OnToMenu { }
public class OnDepositCoin { public BigNumber count; }

/* EXAMPLES

using System;

public class OnRepaintAwake { public IRepaint Marker; }
public class OnUpdateCoin { public BigNumber newCount; }
public class OnUpgrade { }
public class OnOpen { }
public class OnUpdatePassiveIncome { public BigNumber newCount; }
public class OnUpdateInvestor { public BigNumber newCount; }
public class OnUpfateFullMineContainer { }
public class OnUpfateFullLiftContainer { }
public class OnSelectLinz { public ILinzPanelService linzPanel; }

public class OnAddLinz
{
    public Type linzPanelService;
    public LinzComponent linzComponent;

    public OnAddLinz(Type linzPanelService, LinzComponent linzComponent)
    {
        this.linzPanelService = linzPanelService;
        this.linzComponent = linzComponent;
    }
}

*/
