using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;

namespace Drone.Pure
{
    public sealed class DroneBootstrapper
    {
        // These EntityArchetype variables will be used to define how entities are formed(Component)
        public static EntityArchetype droneArchetype;
        public static EntityArchetype helixArchetype;
        public static EntityArchetype helixAttach; // This one is used to attach the Helix transform to the Drone one

        // We hold reference to the render information in these variables(see GetLookFromPrototype)
        public static MeshInstanceRenderer droneLook;
        public static MeshInstanceRenderer helixLook;

        // This command allows us to execute the code even when the script is not a MonoBehaviour
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            // We define our archetypes here, for example for the drone, we say that they have a Position, Rotation and MoveSpeed components
            droneArchetype = entityManager.CreateArchetype(typeof(Position), typeof(Rotation), typeof(MoveSpeed));
            helixArchetype = entityManager.CreateArchetype(typeof(Position), typeof(Rotation), typeof(RotationSpeed));
            helixAttach = entityManager.CreateArchetype(typeof(Attach));
        }

        // Once the scene is loaded, we 
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void InitializeAfterSceneLoad()
        {
            droneLook = GetLookFromPrototype("PlayerRenderPrototype");
            helixLook = GetLookFromPrototype("HelixRenderPrototype");

            NewGame();
        }

        public static void NewGame()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            // We create an entity with the archetype we previously defined (warning, won't have any default values)
            Entity drone = entityManager.CreateEntity(droneArchetype);
            Entity helix = entityManager.CreateEntity(helixArchetype);

            // We set the data for each component in our entity here
            entityManager.SetComponentData(drone, new Position { Value = new float3(0, 1.0f, 0) });
            entityManager.SetComponentData(drone, new Rotation { Value = quaternion.identity });
            entityManager.SetComponentData(drone, new MoveSpeed { speed = 1.0f });
            entityManager.AddSharedComponentData(drone, droneLook); // see that we are adding and setting the look, will be the same for all

            entityManager.SetComponentData(helix, new Position { Value = new float3(-1, -0.25f, 1) });
            entityManager.SetComponentData(helix, new Rotation { Value = quaternion.identity });
            entityManager.SetComponentData(helix, new RotationSpeed { Value = 1000.0f });
            entityManager.AddSharedComponentData(helix, helixLook);

            // This is the part were we parent the helix to the drone (we have just 1 for this demo)
            Entity helixAttachEntity = entityManager.CreateEntity(helixAttach);
            entityManager.SetComponentData(helixAttachEntity, new Attach
            {
                Child = helix,
                Parent = drone
            });
        }

        // This method helps us initialize the renderer properties for our objects
        // Searches for a game  oject in the scene to extract the mesh configuration
        // We use it for both the drones and the helices
        private static MeshInstanceRenderer GetLookFromPrototype(string protoName)
        {
            var proto = GameObject.Find(protoName);
            var result = proto.GetComponent<MeshInstanceRendererComponent>().Value;
            Object.Destroy(proto);
            return result;
        }
    }
}
