using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CardActionsManager
{
 public void setActiveCardAction(ButtonAction cardAction);
 public ButtonAction getActiveCardAction();
 public bool isActiveCardActionSelectable();
 public ButtonAction getCardActionToExecute();
 public void setCardActionToExecute(ButtonAction cardAction);
 public void reset();
}
