using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Reflection;
using SimpelElementEditor.ESO;
using System.Collections;
using System.Drawing.Design;          // <-- voor UITypeEditor
using System.Windows.Forms;           // <-- voor ListBox en FormControls
using System.Windows.Forms.Design;   // <-- voor IWindowsFormsEditorService
using SimpelElementEditor.ESO.Elements;

namespace SimpelElementEditor.ESO.aiPolicy
{
    public class parameters
    {
        public class o_attact
        {
            public int uType { get; set; }
            public static o_attact Read(BinaryReader br)
            {
                o_attact attact = new o_attact();
                attact.uType = br.ReadInt32();
                return attact;
            }
            public void Write(BinaryWriter bw, o_attact attact)
            {
                bw.Write(attact.uType);
            }
        }
        public class o_use_skill
        {
            [Reader.LookupType(typeof(Skills.skill))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int uSkill { get; set; }
            public int uLevel { get; set; }
            public static o_use_skill Read(BinaryReader br)
            {
                o_use_skill use_skill = new o_use_skill();
                use_skill.uSkill = br.ReadInt32();
                use_skill.uLevel = br.ReadInt32();
                return use_skill;
            }
            public void Write(BinaryWriter bw, o_use_skill use_skill)
            {
                bw.Write(use_skill.uSkill);
                bw.Write(use_skill.uLevel);
            }
        }
        public class o_talk
        {
            public string szData { get; set; }
            public static o_talk Read(BinaryReader br)
            {
                o_talk talk = new o_talk();
                int length = br.ReadInt32();
                talk.szData = Encoding.Unicode.GetString(br.ReadBytes(length));
                return talk;
            }
            public void Write(BinaryWriter bw, o_talk talk)
            {
                Console.WriteLine("CANT WRITE TEXT YET!!!");
            }
        }
        public class o_reset_hate_list
        {
            public static o_reset_hate_list Read(BinaryReader br)
            {
                return new o_reset_hate_list();
            }
            public void Write(BinaryWriter bw, o_reset_hate_list o_reset_hate_list)
            {
            }
        }
        public class o_run_trigger
        {
            public int uID { get; set; }
            public static o_run_trigger Read(BinaryReader br)
            {
                o_run_trigger run_trigger = new o_run_trigger();
                run_trigger.uID = br.ReadInt32();
                return run_trigger;
            }
            public void Write(BinaryWriter bw, o_run_trigger run_trigger)
            {
                bw.Write(run_trigger.uID);
            }
        }
        public class o_stop_trigger
        {
            public int uID { get; set; }
            public static o_stop_trigger Read(BinaryReader br)
            {
                o_stop_trigger stop_trigger = new o_stop_trigger();
                stop_trigger.uID = br.ReadInt32();
                return stop_trigger;
            }
            public void Write(BinaryWriter bw, o_stop_trigger stop_trigger)
            {
                bw.Write(stop_trigger.uID);
            }
        }
        public class o_active_trigger
        {
            public int uID { get; set; }
            public static o_active_trigger Read(BinaryReader br)
            {
                o_active_trigger active_trigger = new o_active_trigger();
                active_trigger.uID = br.ReadInt32();
                return active_trigger;
            }
            public void Write(BinaryWriter bw, o_active_trigger active_trigger)
            {
                bw.Write(active_trigger.uID);
            }
        }
        public class o_create_timer
        {
            public int uID { get; set; }
            public int uPediod { get; set; }
            public int uCounter { get; set; }
            public static o_create_timer Read(BinaryReader br)
            {
                o_create_timer create_timer = new o_create_timer();
                create_timer.uID = br.ReadInt32();
                create_timer.uPediod = br.ReadInt32();
                create_timer.uCounter = br.ReadInt32();
                return create_timer;
            }
            public void Write(BinaryWriter bw, o_create_timer create_timer)
            {
                bw.Write(create_timer.uID);
                bw.Write(create_timer.uPediod);
                bw.Write(create_timer.uCounter);
            }
        }
        public class o_kill_timer
        {
            public int uID { get; set; }
            public static o_kill_timer Read(BinaryReader br)
            {
                o_kill_timer kill_timer = new o_kill_timer();
                kill_timer.uID = br.ReadInt32();
                return kill_timer;
            }
            public void Write(BinaryWriter bw, o_kill_timer kill_timer)
            {
                bw.Write(kill_timer.uID);
            }
        }
        public class o_flee
        {
            public static o_flee Read(BinaryReader br)
            {
                return new o_flee();
            }
            public void Write(BinaryWriter bw, o_flee flee)
            {
            }
        }
        public class o_set_hate_to_first
        {
            public static o_set_hate_to_first Read(BinaryReader br)
            {
                return new o_set_hate_to_first();
            }
            public void Write(BinaryWriter bw, o_set_hate_to_first set_hate_to_first)
            {
            }
        }
        public class o_set_hate_to_last
        {
            public static o_set_hate_to_last Read(BinaryReader br)
            {
                return new o_set_hate_to_last();
            }
            public void Write(BinaryWriter bw, o_set_hate_to_last set_hate_to_last)
            {
            }
        }
        public class o_set_hate_fifty_percent
        {
            public static o_set_hate_fifty_percent Read(BinaryReader br)
            {
                return new o_set_hate_fifty_percent();
            }
            public void Write(BinaryWriter bw, o_set_hate_fifty_percent set_hate_fifty_percent)
            {
            }
        }
        public class o_skip_operation
        {
            public static o_skip_operation Read(BinaryReader br)
            {
                return new o_skip_operation();
            }
            public void Write(BinaryWriter bw, o_skip_operation skip_operation)
            {
            }
        }
        public class o_active_controller
        {
            public int uID { get; set; }
            public bool bStop { get; set; }
            public byte undefined1 { get; set; }//not used?
            public byte undefined2 { get; set; }//not used?
            public byte undefined3 { get; set; }//not used?
            public static o_active_controller Read(BinaryReader br)
            {
                o_active_controller active_controller = new o_active_controller();
                active_controller.uID = br.ReadInt32();
                active_controller.bStop = br.ReadBoolean();
                active_controller.undefined1 = br.ReadByte();
                active_controller.undefined2 = br.ReadByte();
                active_controller.undefined3 = br.ReadByte();
                return active_controller;
            }
            public void Write(BinaryWriter bw, o_active_controller active_controller)
            {
                bw.Write(active_controller.uID);
                bw.Write(active_controller.uID);
                bw.Write(active_controller.bStop);
                bw.Write(active_controller.undefined1);
                bw.Write(active_controller.undefined2);
                bw.Write(active_controller.undefined3);
            }
        }
        public class o_summon
        {
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int uMounsterID { get; set; } //yes it really says mounster ;)
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int uBodyMounsterID { get; set; }
            public int uMounsterNum { get; set; }
            public int uLife { get; set; }
            public string szName { get; set; }
            public float fRange { get; set; }
            public bool bFollow { get; set; }
            public bool bDissear { get; set; }
            public byte undefined { get; set; }
            public byte undefined1 { get; set; }
            public static o_summon Read(BinaryReader br)
            {
                o_summon summon = new o_summon();
                summon.uMounsterID = br.ReadInt32();
                summon.uBodyMounsterID = br.ReadInt32();
                summon.uMounsterNum = br.ReadInt32();
                summon.uLife = br.ReadInt32();
                summon.szName = Encoding.Unicode.GetString(br.ReadBytes(32));
                summon.fRange = br.ReadInt32();
                summon.bFollow = br.ReadBoolean();
                summon.bDissear = br.ReadBoolean();
                summon.undefined = br.ReadByte();
                summon.undefined1 = br.ReadByte();
                return summon;
            }
            public void Write(BinaryWriter bw, o_summon summon)
            {
                bw.Write(summon.uMounsterID);
                bw.Write(summon.uBodyMounsterID);
                bw.Write(summon.uMounsterNum);
                bw.Write(summon.uLife);
                bw.Write(summon.szName);
                bw.Write(summon.fRange);
                bw.Write(summon.bFollow);
                bw.Write(summon.bDissear);
                bw.Write(summon.undefined);
                bw.Write(summon.undefined1);
            }
        }
        public class o_trigger_task
        {
            [Reader.LookupType(typeof(TasksSimple.task))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int uTaskID { get; set; }
            public static o_trigger_task Read(BinaryReader br)
            {
                o_trigger_task trigger_task = new o_trigger_task();
                trigger_task.uTaskID = br.ReadInt32();
                return trigger_task;
            }
            public void Write(BinaryWriter bw, o_trigger_task trigger_task)
            {
                bw.Write(trigger_task.uTaskID);
            }
        }
        public class o_change_path
        {
            public int uPathID { get; set; }
            public static o_change_path Read(BinaryReader br)
            {
                o_change_path change_path = new o_change_path();
                change_path.uPathID = br.ReadInt32();
                return change_path;
            }
            public void Write(BinaryWriter bw, o_change_path change_path)
            {
                bw.Write(change_path.uPathID);
            }
        }
        public class o_dispear
        {
            public static o_dispear Read(BinaryReader br)
            {
                return new o_dispear();
            }
            public void Write(BinaryWriter bw, o_dispear dispear)
            {
            }
        }
        public class o_sneer_monster
        {
            public static o_sneer_monster Read(BinaryReader br)
            {
                return new o_sneer_monster();
            }
            public void Write(BinaryWriter bw, o_sneer_monster sneer_monster)
            {
            }
        }
        public class o_use_range_skill
        {
            [Reader.LookupType(typeof(Skills.skill))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int uSkill { get; set; }
            public int uLevel { get; set; }
            public float fRange { get; set; }
            public static o_use_range_skill Read(BinaryReader br)
            {
                o_use_range_skill use_range_skill = new o_use_range_skill();
                use_range_skill.uSkill = br.ReadInt32();
                use_range_skill.uLevel = br.ReadInt32();
                use_range_skill.fRange = br.ReadSingle();
                return use_range_skill;
            }
            public void Write(BinaryWriter bw, o_use_range_skill use_range_skill)
            {
                bw.Write(use_range_skill.uSkill);
                bw.Write(use_range_skill.uLevel);
                bw.Write(use_range_skill.fRange);
            }
        }
        public class o_summon_mine
        {
            [Reader.LookupType(typeof(MINE_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int uID { get; set; }
            public int nNumber { get; set; }
            public int nLife { get; set; }
            public float fDistance { get; set; }
            public bool bBind { get; set; }
            public byte undefined1 { get; set; }
            public byte undefined2 { get; set; }
            public byte undefined3 { get; set; }
            public static o_summon_mine Read(BinaryReader br)
            {
                o_summon_mine summon_mine = new o_summon_mine();
                summon_mine.uID = br.ReadInt32();
                summon_mine.nNumber = br.ReadInt32();
                summon_mine.nLife = br.ReadInt32();
                summon_mine.fDistance = br.ReadSingle();
                summon_mine.bBind = br.ReadBoolean();
                summon_mine.undefined1 = br.ReadByte();
                summon_mine.undefined2 = br.ReadByte();
                summon_mine.undefined3 = br.ReadByte();
                return summon_mine;
            }
            public void Write(BinaryWriter bw, o_summon_mine summon_mine)
            {
                bw.Write(summon_mine.uID);
                bw.Write(summon_mine.nNumber);
                bw.Write(summon_mine.nLife);
                bw.Write(summon_mine.fDistance);
                bw.Write(summon_mine.bBind);
                bw.Write(summon_mine.undefined1);
                bw.Write(summon_mine.undefined2);
                bw.Write(summon_mine.undefined3);
            }
        }
        public  class o_set_global
        {
            public int iID { get; set; }
            public int iValue { get; set; }
            public static o_set_global Read(BinaryReader br)
            {
                o_set_global set_global = new o_set_global();
                set_global.iID = br.ReadInt32();
                set_global.iValue = br.ReadInt32();
                return set_global;
            }
            public void Write(BinaryWriter bw, o_set_global set_global)
            {
                bw.Write(set_global.iID);
                bw.Write(set_global.iValue);
            }
        }
        public class o_revise_global
        {
            public int iID { get; set; }
            public int iValue { get; set; }
            public static o_revise_global Read(BinaryReader br)
            {
                o_revise_global revise_global = new o_revise_global();
                revise_global.iID = br.ReadInt32();
                revise_global.iValue = br.ReadInt32();
                return revise_global;
            }
            public void Write(BinaryWriter bw, o_revise_global revise_global)
            {
                bw.Write(revise_global.iID);
                bw.Write(revise_global.iValue);
            }
        }
        public class o_active_pk_region //not sure
        {
            public int iID { get; set; }
            public bool bActive { get; set; }
            public byte undefined1 { get; set; }
            public byte undefined2 { get; set; }
            public byte undefined3 { get; set; }
            public static o_active_pk_region Read(BinaryReader br)
            {
                o_active_pk_region active_pk_region = new o_active_pk_region();
                active_pk_region.iID = br.ReadInt32();
                active_pk_region.bActive = br.ReadBoolean();
                active_pk_region.undefined1 = br.ReadByte();
                active_pk_region.undefined2 = br.ReadByte();
                active_pk_region.undefined3 = br.ReadByte();
                return active_pk_region;
            }
            public void Write(BinaryWriter bw, o_active_pk_region active_pk_region)
            {
                bw.Write(active_pk_region.iID);
                bw.Write(active_pk_region.bActive);
                bw.Write(active_pk_region.undefined1);
                bw.Write(active_pk_region.undefined2);
                bw.Write(active_pk_region.undefined3);
            }
        }
        public class o_num
        {
            public static o_num Read(BinaryReader br)
            {
                return new o_num();
            }
            public void Write(BinaryWriter bw, o_num num)
            {
            }
        }
        public static object Read(BinaryReader br, int id)
        {
            if (id == 0)
                return o_attact.Read(br);
            else if (id == 1)
                return o_use_skill.Read(br);
            else if (id == 2)
                return o_talk.Read(br);
            else if (id == 3)
                return o_reset_hate_list.Read(br);
            else if (id == 4)
                return o_run_trigger.Read(br);
            else if (id == 5)
                return o_stop_trigger.Read(br);
            else if (id == 6)
                return o_active_trigger.Read(br);
            else if (id == 7)
                return o_create_timer.Read(br);
            else if (id == 8)
                return o_kill_timer.Read(br);
            else if (id == 9)
                return o_flee.Read(br);
            else if (id == 10)
                return o_set_hate_to_first.Read(br);
            else if (id == 11)
                return o_set_hate_to_last.Read(br);
            else if (id == 12)
                return o_set_hate_fifty_percent.Read(br);
            else if (id == 13)
                return o_skip_operation.Read(br);
            else if (id == 14)
                return o_active_controller.Read(br);
            else if (id == 15)
                return o_summon.Read(br);
            else if (id == 16)
                return o_trigger_task.Read(br);
            else if (id == 17)
                return o_change_path.Read(br);
            else if (id == 18)
                return o_dispear.Read(br);
            else if (id == 19)
                return o_sneer_monster.Read(br);
            else if (id == 20)
                return o_use_range_skill.Read(br);
            else if (id == 21)
                return o_summon_mine.Read(br);
            else if (id == 22)
                return o_set_global.Read(br);
            else if (id == 23)
                return o_revise_global.Read(br);
            else if (id == 24)
                return o_active_pk_region.Read(br);
            else if (id == 25)
                return o_num.Read(br);
            else
                return null;
        }


        public class ParameterDropdownEditor : UITypeEditor
        {
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                // Dropdown-style editor
                return UITypeEditorEditStyle.DropDown;
            }

            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (provider?.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService edSvc)
                {
                    // Creeer een listbox in de dropdown
                    ListBox lb = new ListBox { SelectionMode = SelectionMode.One };

                    // Voeg alle mogelijke parameter types toe
                    var types = typeof(parameters)
            .GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic)
            .Where(t => t.Name.StartsWith("o_"))
            .ToArray(); 
                    lb.Items.AddRange(types);

                    // Selecteer huidige type
                    if (value != null) lb.SelectedItem = value.GetType();

                    lb.SelectedIndexChanged += (s, e) =>
                    {
                        var selectedType = (Type)lb.SelectedItem;
                        value = Activator.CreateInstance(selectedType); // nieuwe instance maken
                        edSvc.CloseDropDown();
                    };

                    edSvc.DropDownControl(lb);
                }

                return value;
            }
        }
    }



    public class parameter_target
    {
        public int target { get; set; }
        public int occupation { get; set; }
        public static parameter_target Read(BinaryReader br)
        {
            parameter_target target = new parameter_target();
            target.target = br.ReadInt32();
            if (target.target == 6)
            {
                target.occupation = br.ReadInt32();
            }
            return target;
        }
        public void write(BinaryWriter bw, parameter_target target)
        {
            bw.Write(target.target);
            if (target.target == 6)
                bw.Write(target.occupation);
        }
    }
    public class Operation
    {
        //public int id;
        [Editor(typeof(parameters.ParameterDropdownEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))] // expandable
        public object parameter { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))] // expandable
        public parameter_target target { get; set; }

        public static Operation Read(BinaryReader br)
        {
            Operation op = new Operation();
            int id = br.ReadInt32();
            op.parameter = parameters.Read(br, id);
            op.target = parameter_target.Read(br);
            return op;
        }

        public void Write(BinaryWriter bw, Operation op)
        {

        }
        public override string ToString()
        {
            if (parameter == null)
                return "";
            string str = parameter.GetType().Name;
            if (parameter != null)
            {
                switch (parameter)
                {
                    case parameters.o_attact attack:
                        // actie voor o_attact
                        str = $"Attack type: {attack.uType}";
                        break;
                    case parameters.o_use_skill skill:
                        // actie voor o_use_skill
                        str = $"Skill: {skill.uSkill}, Level: {skill.uLevel}";
                        break;
                    case parameters.o_talk talk:
                        // actie voor o_talk
                        str = $"Talk text: {talk.szData}";
                        break;
                    default:
                        str = parameter.GetType().Name;
                        break;
                }
            }
            return str;
        }
    }
}
