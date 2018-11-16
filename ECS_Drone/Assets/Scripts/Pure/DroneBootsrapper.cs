using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;

namespace Drone.Pure
{
    public sealed class DroneBootstrapper
    {
        public static EntityArchetype droneArchetype;

        public static MeshInstanceRenderer droneLook;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();
            droneArchetype = entityManager.CreateArchetype(typeof(Position), typeof(MoveSpeed));
            Debug.Log("Initialize 1");
        }

        public static void NewGame()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            Debug.Log("New Game");

            //TODO: Find how to initialize the transform by sending the values
            Entity drone = entityManager.CreateEntity(droneArchetype);

            entityManager.SetComponentData(drone, new Position { Value = new float3(0, 1.0f, 0) });
            entityManager.SetComponentData(drone, new MoveSpeed { speed = 5.0f});
            entityManager.AddSharedComponentData(drone, droneLook);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void InitializeAfterSceneLoad()
        {
            droneLook = GetLookFromPrototype("PlayerRenderPrototype");

            Debug.Log("After sceneload");

            NewGame();
          
        }

        private static MeshInstanceRenderer GetLookFromPrototype(string protoName)
        {
            var proto = GameObject.Find(protoName);
            var result = proto.GetComponent<MeshInstanceRendererComponent>().Value;
            Object.Destroy(proto);
            return result;
        }
    }
}
