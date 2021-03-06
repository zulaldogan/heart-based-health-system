﻿using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Editor
{
    public class HeartTests
    {

        public class TheReplenishMethod
        {
            private Image _image;
            private Heart _heart;

            [SetUp]
            public void BeforeEveryTest()
            {
                _image = new GameObject().AddComponent<Image>();
                _heart = new Heart(_image);
            }

            [Test]
            public void ZeroSetsImageWith0FillToFill()
            {
                _image.fillAmount = 0;
                _heart.Replenish(0);
                Assert.AreEqual(0, _image.fillAmount);
            }

            [Test]
            public void OneSetsImageWith0FillTo25PercentFill()
            {
                _image.fillAmount = 0;
                _heart.Replenish(1);
                Assert.AreEqual(0.25f, _image.fillAmount);
            }

            [Test]
            public void OneSetsImageWith25PercentFillTo50PercentFill()
            {
                _image.fillAmount = 0.25f;
                _heart.Replenish(1);
                Assert.AreEqual(0.5f, _image.fillAmount);
            }

            public class Heart
            {
                private const float FillPerHeartPiece = 0.25f;
                private readonly Image _image;

                public Heart(Image image)
                {
                    _image = image;
                }

                public void Replenish(int numberOfHeartPieces)
                {
                    _image.fillAmount += numberOfHeartPieces * FillPerHeartPiece;
                }
            }
        }
    }
}
