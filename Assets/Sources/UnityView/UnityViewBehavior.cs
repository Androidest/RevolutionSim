using Entitas.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimCore
{
    public class UnityViewBehavior : MonoBehaviour, IPositionListener, IDirectionListener
    {
        GameEntity entity;
        
        public void OnLink(GameEntity _entity)
        {
            entity = _entity;
            entity.AddPositionListener(this);
            entity.AddDirectionListener(this);
            var pos = entity.position.value;
            transform.localPosition = new Vector3(pos.x, pos.y, 0);
            if (_entity.hasDirection)
            {
                var dir = _entity.direction.value;
                transform.localRotation = Quaternion.Euler(0, 0, dir);
            }
        }

        public virtual void OnDirection(GameEntity entity, float value)
        {
            transform.localRotation = Quaternion.Euler(0, 0, value);
        }

        public virtual void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.localPosition = new Vector3(value.x, value.y, 0);
        }

        public virtual void OnUnlink()
        {
            Destroy(gameObject);
        }
    }
}