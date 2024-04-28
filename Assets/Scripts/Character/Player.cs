﻿using System;
using UnityEngine;

namespace escape4u
{
    public class Player : Character
    {
        private Interactor _interactor;
        
        protected override void Awake()
        {
            base.Awake();
            _interactor = GetComponent<Interactor>();
            _interactor.SetController((PlayerController)GetController);
            interactWithObject.AddListener(_interactor.ExecuteAction);
        }
    }
}