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
        public static EntityArchetype helixArchetype;
        public static EntityArchetype helixAttach; 

        public static MeshInstanceRenderer droneLook;
        public static MeshInstanceRenderer helixLook;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();
            droneArchetype = entityManager.CreateArchetype(typeof(Position), typeof(Rotation), typeof(MoveSpeed));
            helixArchetype = entityManager.CreateArchetype(typeof(Position), typeof(Rotation), typeof(RotationSpeed));
            helixAttach = entityManager.CreateArchetype(typeof(Attach));
            Debug.Log("Initialize 1");
        }

        public static void NewGame()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            Debug.Log("New Game");

            //TODO: Find how to initialize the transform by sending the values
            Entity drone = entityManager.CreateEntity(droneArchetype);
            Entity helix = entityManager.CreateEntity(helixArchetype);
            
            entityManager.SetComponentData(drone, new Position { Value = new float3(0, 1.0f, 0) });
            entityManager.SetComponentData(drone, new Rotation { Value = quaternion.identity });
            entityManager.SetComponentData(drone, new MoveSpeed { speed = 1.0f});
            entityManager.AddSharedComponentData(drone, droneLook);

            entityManager.SetComponentData(helix, new Position { Value = new float3(1.0f, 1.0f, .0f) });
            entityManager.SetComponentData(helix, new Rotation { Value = quaternion.identity });
            entityManager.SetComponentData(helix, new RotationSpeed { Value = 1000.0f });
            entityManager.AddSharedComponentData(helix, helixLook);

            Entity helixAttachEntity = entityManager.CreateEntity(helixAttach);
            entityManager.SetComponentData(helixAttachEntity, new Attach
            {
                Child = helix,
                Parent = drone
            });
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void InitializeAfterSceneLoad()
        {
            droneLook = GetLookFromPrototype("PlayerRenderPrototype");
            helixLook = GetLookFromPrototype("HelixRenderPrototype");
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
