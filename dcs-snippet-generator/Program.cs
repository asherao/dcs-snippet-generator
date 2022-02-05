using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcs_snippet_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://wiki.hoggitworld.com/view/Scripting_Documentation_Guide



            //(return, class.function, variables, description)
            var functions = new[] {
                //singletons https://wiki.hoggitworld.com/view/Category:Singleton
                /*
                ("vec3", "atmosphere.getWind","table vec3 ","Returns a velocity vector of the wind at a specified point"),
                ("vec3", "atmosphere.getWindWithTurbulence","table vec3 ","Returns a velocity vector of the wind at a specified point, this time factoring turbulence into the equation."),
                ("number, number", "atmosphere.getTemperatureAndPressure","table vec3 ","Returns the temperature and pressure at a given point in 3d space. Temperature is returned in Kelvins Pressure is returned in Pascals"),
                ("Group","coalition.addGroup","enum countryId , enum groupCategory , table groupData","Dynamically spawns a group of the specified category for the specified country. Group data table is in the same format as created by the mission editor. See country page and group class page for the list of countries by id and group categories. The coalition of the group is defined by the coalition its country belongs to. If the group or any unit within shares a name of an existing group or unit, the existing group or unit will be destroyed when the new group is created. Function can NOT spawn new aircraft with a skill level of \"client\". However in single player a group can be spawned with the skill level of \"Player\". When this occurs the existing player aircraft will be destroyed. If no groupId or unitId is specified or the Ids are shared with existing groups or units, a new Id will be created for the new group."),
                ("Static Object","coalition.addStaticObject","enum countryId , table groupData","	Dynamically spawns a static object belonging to the specified country into the mission. This function follows the same rules as coalition.addGroup except for the object table not perfectly matching the format of a static object as seen in the mission file. - Static Objects name cannot be shared with an existing object, if it is the existing object will be destroyed on the spawning of the new object. - If unitId is not specified or matches an existing object, a new Id will be generated. - Coalition of the object is defined based on the country the object is spawning to."),
                ("table","coalition.getGroups","enum coalitionId , enum GroupCategory","Returns a table of group objects belonging to the specified coalition. If the groupCategory enumerator is provided the table will only contain groups that belong to the specified category. If this optional variable is not provided, all group types will be returned. See here for the list of possible group categories."),
                ("table","coalition.getStaticObjects","enum coalitionId","Returns a table of static objects belonging to the specified coalition."),
                ("table","coalition.getAirbases","enum coalitionId","Returns a table of airbase objects belonging to the specified coalition. Objects can be ships, static objects(FARP), or airbases on the map. When the function is run as world.getAirbases() no input values required, and the function returns all airbases, ships, and farps on the map."),
                ("table","coalition.getPlayers","enum coalitionId","Returns a table of unit objects that are currently occupied by players. Function is useful in multiplayer to easily filter client aircraft from everything else."),
                ("table","coalition.getServiceProviders","enum coalitionId , enum coalition.service","Returns a table of unit objects that provide a given service to player controlled aircraft. Services are ATC, AWACS, TANKER, and FAC."),
                ("function","coalition.addRefPoints","enum coalitionId , table refPoint","Creates a new reference point belonging to the specified coalition. Reference points are used by JTACs."),
                ("table","coalition.getRefPoints","enum coalitionId","Returns a table of reference points as defined by the mission editor or added via scripting. Reference points are used by JTACs."),
                ("vec3","coalition.getMainRefPoint","enum coalitionId","Returns the position of a coalitions \"bullseye\" as specified in the mission editor."),
                ("enum coalitonId","coalition.getCountryCoalition","enum countryId","Returns the enumarator coalitionId that a specified country belongs to."),
                */
                // DCS singleton coord https://wiki.hoggitworld.com/view/DCS_singleton_coord
                /*
                ("vec3","coord.LLtoLO","GeoCoord latitude , GeoCoord longitude , number altitude","Returns a point from latitude and longitude in the vec3 format. Altitude is optional."),
                ("latitude, longitude, altitude","coord.LOtoLL","table vec3 ","Returns multiple values of a given vec3 point in latitude, longitude, and altitude."),
                ("MGRS table","coord.LLtoMGRS","GeoCoord latitude , GeoCoord longitude","	Returns an MGRS table from the latitude and longitude coordinates provided. Note that in order to get the MGRS coordinate from a vec3 you must first use coord.LOtoLL on it."),
                ("latitude, longitude, altitude","coord.MGRStoLL","table MGRS","Returns multiple values of a given in MGRS coordinates and converts it to latitude, longitude, and altitude."),
                 */
                //DCS singleton env https://wiki.hoggitworld.com/view/DCS_singleton_env
                /*
                ("function","env.info","string log , boolean showMessageBox","Prints the passed string to the dcs.log with a prefix of 'info'. The optional variable defines whether or not a message box will pop up when the logging occurs. Bool is optional."),
                ("function","env.warning","string log , boolean showMessageBox","Prints the passed string to the dcs.log with a prefix of 'warning'. The optional variable defines whether or not a message box will pop up when the logging occurs. Bool is optional."),
                ("function","env.error","string log , boolean showMessageBox","Prints the passed string to the dcs.log with a prefix of 'error'. The optional variable defines whether or not a message box will pop up when the logging occurs. Bool is optional."),
                ("function","env.setErrorMessageBoxEnabled","boolean toggle","Sets the value for whether or not an error message box will be displayed if a lua error occurs. By default the error message box will appear."),
                ("string","env.getValueDictByKey","string value","Returns a string associated with the passed dictionary key value. If the key is not found within the miz the function will return the string that was passed."),
                */
                //DCS singleton land https://wiki.hoggitworld.com/view/DCS_singleton_land
                /*
                ("number","land.getHeight","table vec2","Returns the distance from sea level (y-axis) of a given vec2 point."),
                ("number, number","land.getSurfaceHeightWithSeabed","table vec2","Returns the surface height and depth of a point. Useful for checking if the path is deep enough to support a given ship. Both values are positive. When checked over water at sea level the first value is always zero. When checked over water at altitude, for example the reservoir of the Inguri Dam, the first value is the corresponding altitude the water level is at."),
                ("enum","land.getSurfaceType","table vec2","Returns an enumerator for the surface type at a given point. Enumerator is as follows: LAND = 1. SHALLOW_WATER = 2. WATER = 3. ROAD = 4. RUNWAY = 5."),
                ("boolean","land.isVisible","table origin , table destination","xReturns the boolean value if there is an terrain intersection via drawing a virtual line from the origin to the destination. Used for determining line of sight.xx"),
                ("vec3","land.getIP","table origin , table direction , number distance","Returns an intercept point at which a ray drawn from the origin in the passed normalized direction for a specified distance. If no intersection found the function will return nil."),
                ("table of vec3","land.profile","table vec3 , table vec3","Returns a table of vectors that make up the profile of the land between the two passed points. The spacing and quantity of returned vectors is not entirely known to the author. Requires further testing."),
                ("number, number","land.getClosestPointOnRoads","string roadType , number xCoord , number yCoord","Returns a coordinate of the nearest road from the passed point. NOTE that this function does not use vec2 or vec3. It uses individual values representing a vec2 for x and y. Valid road type values: 'roads' and 'railroads'"),
                ("table","land.findPathOnRoads","string roadType , number xCoord , number yCoord , number destX , number destY","Returns a table of points along a that define a route from a starting point to a destination point. Returned table is a table of vec2 points indexed numerically from starting point to destination. Table can return a high number of points over a relatively short route. So expect to iterate through a large number of values. Roadtype can be 'railroads' or 'roads' NOTE!!! A bug exists where the value for railroads is actually 'rails'.This is different from the sister function getClosestPointOnRoads"),
               */
                

                //DCS singleton voiceChat https://wiki.hoggitworld.com/view/DCS_singleton_voiceChat 
                //("nothing","VoiceChat.createRoom","string roomName , number side , number roomType","Creates a VoiceChat room for players to join and interact with each other in a multiplayer mission. Side for which the voice room is available to players. VoiceChat.Side = {NEUTRAL = 0,RED = 1,BLUE = 2,ALL = 3}. The type of room that is created (optional).VoiceChat.RoomType = {PERSISTENT = 0,MULTICREW = 1,MANAGEABLE = 2}"),
               
                /*
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),*/

                
                //DCS singleton timer https://wiki.hoggitworld.com/view/DCS_singleton_timer The timer singleton has two important uses. 1. Return the mission time. 2. To schedule functions.
                ("time","timer.getTime","","Returns the model time in seconds to 3 decimal places. This counts time once the simulator loads. So if a mission is paused, the time this function returns still moves forward."),
                ("time","timer.getAbsTime","","Returns the mission time in seconds. It is relative compared to the mission start time. The default mission start time in the mission editor is Day 1: 12:00:00.In seconds this value is: 43200"),
                ("time","timer.getTime0","","Returns the mission start time in seconds. Can be used with timer.getAbsTime() to see how much time has passed in the mission."),
                ("functionId","timer.scheduleFunction","function functionToCall , functionArgs anyFunctionArguement , time modelTime","Schedules a function to run at a time in the future. This is a very powerful function. The function that is called is expected to return nil or a number which will indicate the next time the function will be rescheduled. Use the second argument in that function to retrieve the current time and add the desired amount of delay(expressed in seconds)"),
                ("function","timer.removeFunction","number functionId","Removes a scheduled function as defined by the functionId from executing. Essentially will \"destroy\" the function."),
                ("function","timer.setFunctionTime","number functionId , time modelTime","Re-Schedules an already scheduled function to run at a different time in the future."),

                // DCS singleton world https://wiki.hoggitworld.com/view/DCS_singleton_world The world singleton contains functions centered around two different but extremely useful functions. 1. Events and event handlers are all governed within world. 2. A number of functions to get information about the game world.
                ("function","world.addEventHandler","EventHandler handler","Adds a function as an event handler that executes whenever a simulator event occurs. The most common uses of event handlers are to track statistics of units within a given scenario and to execute code based on certain events occurring. Handlers are passed event tables which contains numerous data regarding the event. For examples of the event tables returned, reference the event page on the wiki to get more information regarding the event."),
                ("function","world.removeEventHandler","EventHandler handler","Removes the specified event handler from handling events. Use this when an event handler has outlived its usefulness."),
                ("table","world.getPlayer","","Returns a table of the single unit object in the game who's skill level is set as \"Player\". There is only a single player unit in a mission and in single player the user will always spawn into this unit automatically unless other client or Combined Arms slots are available."),
                ("table","world.searchObjects","table/enum Object.Category , volume searchVolume , ObjectSearchHandler Handler , any data","Searches a defined volume of 3d space for the specified objects within it and then can run function on each returned object. Object category is either a single enum or a table of enums that defines the types of objects that will be searched for Search volume is the defined 3d space that will be searched. Handler is the function that will be run on each object that is found. Any data is a variable that is passed to the handler function, it can be anything. Any data is optional."),
                ("table","world.getMarkPanels","","Returns a table of mark panels and drawn shapes indexed numerically that are present within the mission. Panel is designed with the mark points in mind, but still returns data for shapes created via markups."),

                /*
                //TODO: below
                // DCS singleton missionCommands https://wiki.hoggitworld.com/view/DCS_singleton_missionCommands The missionCommands singleton allows for greater access and flexibility of use for the F10 Other radio menu. Added commands can contain sub-menus and directly call lua functions.
                ("xxx","missionCommands.addCommand","xxx","xxx"),
                ("xxx","missionCommands.addSubMenu","xxx","xxx"),
                ("xxx","missionCommands.removeItem","xxx","xxx"),
                ("xxx","missionCommands.addCommandForCoalition","xxx","xxx"),
                ("xxx","missionCommands.addSubMenuForCoalition","xxx","xxx"),
                ("xxx","missionCommands.removeItemForCoalition","xxx","xxx"),
                ("xxx","missionCommands.addCommandForGroup","xxx","xxx"),
                ("xxx","missionCommands.addSubMenuForGroup","xxx","xxx"),
                ("xxx","missionCommands.removeItemForGroup","xxx","xxx"),

                //DCS singleton net https://wiki.hoggitworld.com/view/DCS_singleton_net The net singleton are a number of functions from the network API that work in the mission scripting environment. Notably for mission scripting purposes there is now a way to send chat, check if players are in Combined Arms slots, kick people from the server, and move players to certain slots.
                ("xxx","net.send_chat","xxx","xxx"),
                ("xxx","net.send_chat_to","xxx","xxx"),
                ("xxx","net.get_player_list","xxx","xxx"),
                ("xxx","net.get_my_player_id","xxx","xxx"),
                ("xxx","net.get_server_id","xxx","xxx"),
                ("xxx","net.get_player_info","xxx","xxx"),
                ("xxx","net.kick","xxx","xxx"),
                ("xxx","net.get_stat","xxx","xxx"),
                ("xxx","net.get_name","xxx","xxx"),
                ("xxx","net.get_slot","xxx","xxx"),
                ("xxx","net.lua2json","xxx","xxx"),
                ("xxx","net.json2lua","xxx","xxx"),
                ("xxx","net.dostring_in","xxx","xxx"),

                //DCS singleton trigger https://wiki.hoggitworld.com/view/DCS_singleton_trigger The trigger singleton contains a number of functions that mimic actions and conditions found within the mission editor triggers. As a result these functions provide an easy way to interface with triggers setup within the mission editor. Additionally a few trigger functions act as a gateway between mission editor triggers and related scripting functions.
                ("xxx","trigger.action.ctfColorTag","xxx","xxx"),
                ("xxx","trigger.action.getUserFlag","xxx","xxx"),
                ("xxx","trigger.action.setUserFlag","xxx","xxx"),
                ("xxx","trigger.misc.getZone","xxx","xxx"),
                ("xxx","trigger.action.explosion","xxx","xxx"),
                ("xxx","trigger.action.smoke","xxx","xxx"),
                ("xxx","trigger.action.effectSmokeBig","xxx","xxx"),
                ("xxx","trigger.action.effectSmokeStop","xxx","xxx"),
                ("xxx","trigger.action.illuminationBomb","xxx","xxx"),
                ("xxx","trigger.action.signalFlare","xxx","xxx"),
                ("xxx","trigger.action.radioTransmission","xxx","xxx"),
                ("xxx","trigger.action.stopRadioTransmission","xxx","xxx"),
                ("xxx","trigger.action.setUnitInternalCargo","xxx","xxx"),
                ("xxx","trigger.action.outSound","xxx","xxx"),
                ("xxx","trigger.action.outSoundForCoalition","xxx","xxx"),
                ("xxx","trigger.action.outSoundForCountry","xxx","xxx"),
                ("xxx","trigger.action.outSoundForGroup","xxx","xxx"),
                ("xxx","trigger.action.outText","xxx","xxx"),
                ("xxx","trigger.action.outTextForCoalition","xxx","xxx"),
                ("xxx","trigger.action.outTextForCountry","xxx","xxx"),
                ("xxx","trigger.action.outTextForGroup","xxx","xxx"),
                ("xxx","trigger.action.addOtherCommand","xxx","xxx"),
                ("xxx","trigger.action.removeOtherCommand","xxx","xxx"),
                ("xxx","trigger.action.AddOtherCommandForCoalition","xxx","xxx"),
                ("xxx","trigger.action.removeOtherCommandForCoalition","xxx","xxx"),
                ("xxx","trigger.action.addOtherCommandForGroup","xxx","xxx"),
                ("xxx","trigger.action.removeOtherCommandForGroup","xxx","xxx"),
                ("xxx","trigger.action.markToAll","xxx","xxx"),
                ("xxx","trigger.action.markToCoalition","xxx","xxx"),
                ("xxx","trigger.action.markToGroup","xxx","xxx"),
                ("xxx","trigger.action.removeMark","xxx","xxx"),
                ("xxx","trigger.action.markupToAll","xxx","xxx"),
                ("xxx","trigger.action.lineToAll","xxx","xxx"),
                ("xxx","trigger.action.circleToAll","xxx","xxx"),
                ("xxx","trigger.action.rectToAll","xxx","xxx"),
                ("xxx","trigger.action.quadToAll","xxx","xxx"),
                ("xxx","trigger.action.textToAll","xxx","xxx"),
                ("xxx","trigger.action.arrowToAll","xxx","xxx"),
                ("xxx","trigger.action.setMarkupRadius","xxx","xxx"),
                ("xxx","trigger.action.setMarkupText","xxx","xxx"),
                ("xxx","trigger.action.setMarkupFontSize","xxx","xxx"),
                ("xxx","trigger.action.setMarkupColor","xxx","xxx"),
                ("xxx","trigger.action.setMarkupColorFill","xxx","xxx"),
                ("xxx","trigger.action.setMarkupTypeLine","xxx","xxx"),
                ("xxx","trigger.action.setMarkupPositionEnd","xxx","xxx"),
                ("xxx","trigger.action.setMarkupPositionStart","xxx","xxx"),
                ("xxx","trigger.action.setAITask","xxx","xxx"),
                ("xxx","trigger.action.pushAITask","xxx","xxx"),
                ("xxx","trigger.action.activateGroup","xxx","xxx"),
                ("xxx","trigger.action.deactivateGroup","xxx","xxx"),
                ("xxx","trigger.action.setGroupAIOn","xxx","xxx"),
                ("xxx","trigger.action.setGroupAIOff","xxx","xxx"),
                ("xxx","trigger.action.groupStopMoving","xxx","xxx"),
                ("xxx","trigger.action.groupContinueMoving","xxx","xxx"),
                */
            };


            
             //Console.Write(information[1].Item1);
            //(return, class.function, variables, description)
            foreach (var function in functions)
            {
                Console.WriteLine("\"" + function.Item2 + "\": {");
                Console.WriteLine("\"prefix\": \"" + function.Item2 + "\",");
                Console.WriteLine("\"body\": [");
                Console.WriteLine("\"" + function.Item2 + "(${1:" + function.Item3 + "})" + "\",");
                Console.WriteLine("\"$0\"");
                Console.WriteLine("],");
                Console.WriteLine("\"description\": \"" + "Returns " + function.Item1 + ". " + function.Item4 + "\"");
                Console.WriteLine("}");
                Console.WriteLine(",");
            }
            Console.ReadKey();
        }
    }
}
