using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Requirements : NonPersistantSingleton<Requirements> {
  public BedRequirement[] bucle;
  public BedRequirement crytical;
  public BedRequirement dead;
}
