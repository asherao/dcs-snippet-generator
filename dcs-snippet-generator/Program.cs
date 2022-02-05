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
                
                ("number","land.getHeight","table vec2","Returns the distance from sea level (y-axis) of a given vec2 point."),
                ("number, number","land.getSurfaceHeightWithSeabed","table vec2","Returns the surface height and depth of a point. Useful for checking if the path is deep enough to support a given ship. Both values are positive. When checked over water at sea level the first value is always zero. When checked over water at altitude, for example the reservoir of the Inguri Dam, the first value is the corresponding altitude the water level is at."),
                ("enum","land.getSurfaceType","table vec2","Returns an enumerator for the surface type at a given point. Enumerator is as follows: LAND = 1. SHALLOW_WATER = 2. WATER = 3. ROAD = 4. RUNWAY = 5."),
                ("boolean","land.isVisible","table origin , table destination","xReturns the boolean value if there is an terrain intersection via drawing a virtual line from the origin to the destination. Used for determining line of sight.xx"),
                ("vec3","land.getIP","table origin , table direction , number distance","Returns an intercept point at which a ray drawn from the origin in the passed normalized direction for a specified distance. If no intersection found the function will return nil."),
                ("table of vec3","land.profile","table vec3 , table vec3","Returns a table of vectors that make up the profile of the land between the two passed points. The spacing and quantity of returned vectors is not entirely known to the author. Requires further testing."),
                ("number, number","land.getClosestPointOnRoads","string roadType , number xCoord , number yCoord","Returns a coordinate of the nearest road from the passed point. NOTE that this function does not use vec2 or vec3. It uses individual values representing a vec2 for x and y. Valid road type values: 'roads' and 'railroads'"),
                ("table","land.findPathOnRoads","string roadType , number xCoord , number yCoord , number destX , number destY","Returns a table of points along a that define a route from a starting point to a destination point. Returned table is a table of vec2 points indexed numerically from starting point to destination. Table can return a high number of points over a relatively short route. So expect to iterate through a large number of values. Roadtype can be 'railroads' or 'roads' NOTE!!! A bug exists where the value for railroads is actually 'rails'.This is different from the sister function getClosestPointOnRoads"),
                /*("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),
                ("xxx","xxx","xxx","xxx"),*/
              



/*
map.Add("coord.LLtoLO",
map.Add("coord.LOtoLL",
map.Add("coord.LLtoMGRS",
map.Add("coord.MGRStoLL",
map.Add("coalition.addGroup",
map.Add("coalition.addStaticObject",
map.Add("coalition.getGroups",
map.Add("coalition.getStaticObjects",
map.Add("coalition.getAirbases",
map.Add("coalition.getPlayers",
map.Add("coalition.getServiceProviders",
map.Add("coalition.addRefPoints",
map.Add("coalition.getRefPoints",
map.Add("coalition.getMainRefPoint",
map.Add("coalition.getCountryCoalition",
map.Add("env.info",
map.Add("env.warning",
map.Add("env.error",
map.Add("env.setErrorMessageBoxEnabled",
map.Add("env.getValueDictByKey",
map.Add("land.getHeight",
map.Add("land.getSurfaceHeightWithSeabed",
map.Add("land.getSurfaceType",
map.Add("land.isVisible",
map.Add("land.getIP",
map.Add("land.profile",
map.Add("land.getClosestPointOnRoads",
map.Add("land.findPathOnRoads",
map.Add("missionCommands.addCommand",
map.Add("missionCommands.addSubMenu",
map.Add("missionCommands.removeItem",
map.Add("missionCommands.addCommandForCoalition",
map.Add("missionCommands.addSubMenuForCoalition",
map.Add("missionCommands.removeItemForCoalition",
map.Add("missionCommands.addCommandForGroup",
map.Add("missionCommands.addSubMenuForGroup",
map.Add("missionCommands.removeItemForGroup",
map.Add("net.send_chat",
map.Add("net.send_chat_to",
map.Add("net.get_player_list",
map.Add("net.get_my_player_id",
map.Add("net.get_server_id",
map.Add("net.get_player_info",
map.Add("net.kick",
map.Add("net.get_stat",
map.Add("net.get_name",
map.Add("net.get_slot",
map.Add("net.lua2json",
map.Add("net.json2lua",
map.Add("net.dostring_in",
map.Add("timer.getTime",
map.Add("timer.getAbsTime",
map.Add("timer.getTime0",
map.Add("timer.scheduleFunction",
map.Add("timer.removeFunction",
map.Add("timer.setFunctionTime",
map.Add("VoiceChat.createRoom",
map.Add("world.addEventHandler",
map.Add("world.removeEventHandler",
map.Add("world.getPlayer",
map.Add("world.searchObjects",
map.Add("world.getMarkPanels",
map.Add("trigger.action.ctfColorTag",
map.Add("trigger.action.getUserFlag",
map.Add("trigger.action.setUserFlag",
map.Add("trigger.misc.getZone",
map.Add("trigger.action.explosion",
map.Add("trigger.action.smoke",
map.Add("trigger.action.effectSmokeBig",
map.Add("trigger.action.effectSmokeStop",
map.Add("trigger.action.illuminationBomb",
map.Add("trigger.action.signalFlare",
map.Add("trigger.action.radioTransmission",
map.Add("trigger.action.stopRadioTransmission",
map.Add("trigger.action.setUnitInternalCargo",
map.Add("trigger.action.outSound",
map.Add("trigger.action.outSoundForCoalition",
map.Add("trigger.action.outSoundForCountry",
map.Add("trigger.action.outSoundForGroup",
map.Add("trigger.action.outText",
map.Add("trigger.action.outTextForCoalition",
map.Add("trigger.action.outTextForCountry",
map.Add("trigger.action.outTextForGroup",
map.Add("trigger.action.addOtherCommand",
map.Add("trigger.action.removeOtherCommand",
map.Add("trigger.action.AddOtherCommandForCoalition",
map.Add("trigger.action.removeOtherCommandForCoalition",
map.Add("trigger.action.addOtherCommandForGroup",
map.Add("trigger.action.removeOtherCommandForGroup",
map.Add("trigger.action.markToAll",
map.Add("trigger.action.markToCoalition",
map.Add("trigger.action.markToGroup",
map.Add("trigger.action.removeMark",
map.Add("trigger.action.markupToAll",
map.Add("trigger.action.lineToAll",
map.Add("trigger.action.circleToAll",
map.Add("trigger.action.rectToAll",
map.Add("trigger.action.quadToAll",
map.Add("trigger.action.textToAll",
map.Add("trigger.action.arrowToAll",
map.Add("trigger.action.setMarkupRadius",
map.Add("trigger.action.setMarkupText",
map.Add("trigger.action.setMarkupFontSize",
map.Add("trigger.action.setMarkupColor",
map.Add("trigger.action.setMarkupColorFill",
map.Add("trigger.action.setMarkupTypeLine",
map.Add("trigger.action.setMarkupPositionEnd",
map.Add("trigger.action.setMarkupPositionStart",
map.Add("trigger.action.setAITask",
map.Add("trigger.action.pushAITask",
map.Add("trigger.action.activateGroup",
map.Add("trigger.action.deactivateGroup",
map.Add("trigger.action.setGroupAIOn",
map.Add("trigger.action.setGroupAIOff",
map.Add("trigger.action.groupStopMoving",
map.Add("trigger.action.groupContinueMoving",
//Group https://wiki.hoggitworld.com/view/DCS_Class_Group

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
