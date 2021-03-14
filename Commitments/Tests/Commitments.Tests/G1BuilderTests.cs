﻿using System.Linq;
using Commitments.Builders;
using Commitments.Tests.Fixtures;
using mcl;
using Xunit;

namespace Commitments.Tests
{
    [Collection("Sequential")]
    public class G1BuilderTests : IClassFixture<CommitmentTestFixture>
    {

        [Fact]
        public void G1BuilderShouldHaveExactValueGivenSpecificParameters()
        {
            // Arrange
            var secret = new MCL.Fr();
            secret.SetStr("1927409816240961209460912649124", 10);

            // Act
            var g1 = new G1Builder().Build(17, secret);

            // Assert
            var values = g1.Select(point => point.GetStr(10)).ToList();

            var expected = new[]
            {
                "1 3685416753713387016781088315183077757961620795782546409894578378688607592378376318836054947676345821548104185464507 1339506544944476473020471379941921221584933875938349620426543736416511423956333506472724655353366534992391756441569",
                "1 2152869591689196284448695346189574884812111481958382828258011215851576980696076283357586937048281406709538669668556 1837985193201176164563363095685788695060722952730414729513827449189998486108746221085867464994192483925080285065018",
                "1 3262605383935052083682746418410148264888435523851787883646428634651057127775051437848295094756022375626344454529853 170376908770402617588871716106905630704800483257535202301637743269417617389615424187202633271003852068580182760145",
                "1 880220465676249036392707021793508724521687313339128521628378026681982232143465812471317982023333854734330480948673 2902223523920951554723894475268175106169924753723683323415827815697283974835754478310015241899366201222645054649608",
                "1 3244388122438103216409647202891415823727015100716970678191779835123826603745878948836800400002635659162267031975583 1585253991742417487161783435845975575940496801371133300360989731905095816244520655199543596433385055483512833757601",
                "1 1691444095738545636838570153348610026182961225323356293730618623455617099056679194783075235346140714244554956873033 961647227525848937006956574637866372979536342809091069926681629924395961591459720348224030656076442822973218085550",
                "1 3577901166225087165094130311167725910816358129621364033783794190115179171035326630844229271546155259801088983862479 3092642789043285621253509221940543294037789204421586765911962911994791146080221763753835525158184924558752020565291",
                "1 3013186384424179439775834119326464143135586883979982227880894049363998889225981543565484795480442461763905556101762 2478178060772079991661592547244530979985617852562178845899785854640900915922275633937010001028451411707598232298832",
                "1 2399231498671876712809138864159907535047647996068498551664715372729570379868491143868576593216337700083434635379685 482713507023481840088214347482905793358357894612071198190992625150626572379700355268448916577827133516290766497622",
                "1 3969977694904317593192991000252371163313871217135365989839005125424170023895776071038962785493744895844713942612974 4413699249467038796028960432613629427107969427001375982715766204951543003390119367884220008325083276852454909781",
                "1 194075085492710730179274360855839046245139911409378180773739622831795665144267111066969149760214641537576331892106 2829985443790966823527351173358032012294116269530327251028202388989851835102944896169897747047401344807088160112615",
                "1 3280685826964465549968732412388399530552593104925613549928682916052288843943420728109800551779100636680533358924443 298681365483796231406540809779630027096164486961762590101806824599619177657034359801891143498721811778563760637265",
                "1 3400935219571983529219239890354858045697412824966239298938573345769483174728220352364464899823354648929772679742552 191348415359823743448098111145821414668135484237623052156975028197191932451915485624239658088947171507703851149457",
                "1 3374538774097525861555904858666250834790705983053158676667960471408213151238217454016543185985604089823231022873495 3258515632833107359343766033193307526227113423713039039660926225561152436287447196511646604996224783556594615862297",
                "1 84257718831135536599708664101759228548259087509946180939819270114426033813393924094069423610123184508861693807222 1425072665498715675588703937845375337020452759807133251766395540291673980878175955156843196123520432067102459055363",
                "1 3252002729706195882623612396123269947851274285378019889513328537606104266375911074185178476483143881219657281907365 2744825182574836694639045426047274581117055175119425124924870369929899567807025339868314937727954579104158715615767",
                "1 3105530220482690203381088120196667002396187280376878591204985144810501655541159693720070013410365841734894244215545 2515128161348588248190794853040865399542397670879510720694265058064715843238549344693260209850633864871507776822678"
            };

            Assert.Equal(expected, values);
        }

        [Fact]
        public void G1BuilderGeneratorShouldNotBeZero()
        {
            // Arrange
            var builder = new G1Builder();

            // Act
            var isZero = builder.Generator.IsZero();

            // Assert
            Assert.False(isZero);
        }

        [Fact]
        public void G1BuilderGeneratorShouldBeValid()
        {
            // Arrange
            var builder = new G1Builder();

            // Act
            var isValid = builder.Generator.IsValid();

            // Assert
            Assert.True(isValid);
        }
    }
}