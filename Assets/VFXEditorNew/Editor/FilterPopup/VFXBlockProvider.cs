using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.VFX;

namespace UnityEditor.VFX.UI
{
    public class VFXBlockProvider : VFXFilterWindow.IProvider
    {
        VFXContextPresenter m_ContextPresenter;
        AddBlock m_onAddBlock;
        //VFXBlock m_blockModel;

        public class VFXBlockElement : VFXFilterWindow.Element
        {
            public VFXBlockDesc m_Desc;
            public AddBlock m_SpawnCallback;

            internal VFXBlockElement(int level, VFXBlockDesc desc, AddBlock spawncallback)
            {
                this.level = level;
                content = new GUIContent(VFXInfoAttribute.Get(desc).category.Replace("/"," ")+" : " + desc.Name/*, VFXEditor.styles.GetIcon(desc.Icon)*/);
                m_Desc = desc;
                m_SpawnCallback = spawncallback;
            }
        }

        public delegate void AddBlock(int index, VFXBlockDesc desc);

        internal VFXBlockProvider(/*Vector2 mousePosition, */VFXContextPresenter contextModel, AddBlock onAddBlock)
        {
            //m_mousePosition = mousePosition;
            m_ContextPresenter = contextModel;
            //m_blockModel = null;
            m_onAddBlock = onAddBlock;
        }

        public void CreateComponentTree(List<VFXFilterWindow.Element> tree)
        {
            tree.Add(new VFXFilterWindow.GroupElement(0, "NodeBlocks"));

            var blocks = new List<VFXBlockDesc>(VFXLibrary.GetBlocks());

            var filteredBlocks = blocks.Where(b => m_ContextPresenter.Model.Accept(b)).ToList();

            filteredBlocks.Sort((blockA, blockB) => {

                var infoA = VFXInfoAttribute.Get(blockA); ;
                var infoB = VFXInfoAttribute.Get(blockB);

                int res = infoA.category.CompareTo(infoB.category);
                return res != 0 ? res : blockA.Name.CompareTo(blockB.Name);
            });

            HashSet<string> categories = new HashSet<string>();

            foreach(VFXBlockDesc desc in filteredBlocks)
            {
                int i = 0;

                var category = VFXInfoAttribute.Get(desc).category;

                if (!categories.Contains(category) && category != "")
                {
                    string[] split = category.Split('/');
                    string current = "";

                    while(i < split.Length)
                    {
                        current += split[i];
                        if(!categories.Contains(current))
                            tree.Add(new VFXFilterWindow.GroupElement(i+1,split[i]));
                        i++;
                        current += "/";
                    }
                    categories.Add(category);
                }
                else
                {
                    i = category.Split('/').Length;
                }

                if (category != "")
                    i++;

                tree.Add(new VFXBlockElement(i, desc, m_onAddBlock));

            }
        }
        
        public bool GoToChild(VFXFilterWindow.Element element, bool addIfComponent)
        {
            if (element is VFXBlockElement)
            {
                VFXBlockElement blockElem = element as VFXBlockElement;
                
                blockElem.m_SpawnCallback(-1,blockElem.m_Desc);
                return true;
            }

            return false;
        }
    }
}
