/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.Engine.Geometry;
using BH.oM.Environment.Elements;
using BH.oM.Base;
using System.Text.Json.Serialization;
using System.ComponentModel;
using BH.oM.Environment.SAP;

namespace BH.Engine.Environment.SAP
{
    //Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

    public class ResultJson : BHoMObject, IResultObject
    { 
            [JsonPropertyName("pressureTestCode.")]
            public int PressureTestCode { get; set; }

            [JsonPropertyName("isq50YS.")]
            public string Isq50YS { get; set; }

            [JsonPropertyName("engineVersionNumber.")]
            public string EngineVersionNumber { get; set; }

            [JsonPropertyName("sapCalcType.")]
            public string SapCalcType { get; set; }

            [JsonPropertyName("sctFlag.")]
            public string SctFlag { get; set; }

            [JsonPropertyName("improvedDwellingFlag.")]
            public string ImprovedDwellingFlag { get; set; }

            [JsonPropertyName("title.")]
            public string Title { get; set; }

            [JsonPropertyName("date.")]
            public string Date { get; set; }

            [JsonPropertyName("rrn.")]
            public string Rrn { get; set; }

            [JsonPropertyName("uprn.")]
            public string Uprn { get; set; }

            [JsonPropertyName("immersionFlag.")]
            public string ImmersionFlag { get; set; }

            [JsonPropertyName("sapCommunityWaterOnlyFlag.")]
            public string SapCommunityWaterOnlyFlag { get; set; }

            [JsonPropertyName("sapFlag.")]
            public string SapFlag { get; set; }

            [JsonPropertyName("v1b3c_sap.")]
            public List<string> V1b3cSap { get; set; }

            [JsonPropertyName("v4.")]
            public string V4 { get; set; }

            [JsonPropertyName("v5.")]
            public string V5 { get; set; }

            [JsonPropertyName("v6a.")]
            public string V6a { get; set; }

            [JsonPropertyName("v6b.")]
            public string V6b { get; set; }

            [JsonPropertyName("v7a.")]
            public string V7a { get; set; }

            [JsonPropertyName("v7b.")]
            public string V7b { get; set; }

            [JsonPropertyName("v7c.")]
            public string V7c { get; set; }

            [JsonPropertyName("v8.")]
            public string V8 { get; set; }

            [JsonPropertyName("v17.")]
            public string V17 { get; set; }

            [JsonPropertyName("v18.")]
            public string V18 { get; set; }

            [JsonPropertyName("v19.")]
            public string V19 { get; set; }

            [JsonPropertyName("v20.")]
            public string V20 { get; set; }

            [JsonPropertyName("v21.")]
            public string V21 { get; set; }

            [JsonPropertyName("v22m.")]
            public string V22m { get; set; }

            [JsonPropertyName("v22am.")]
            public string V22am { get; set; }

            [JsonPropertyName("v22bm.")]
            public string V22bm { get; set; }

            [JsonPropertyName("v23a.")]
            public string V23a { get; set; }

            [JsonPropertyName("v23b.")]
            public string V23b { get; set; }

            [JsonPropertyName("v23c.")]
            public string V23c { get; set; }

            [JsonPropertyName("v25m.")]
            public string V25m { get; set; }

            [JsonPropertyName("V26AUList.")]
            public List<string> V26AUList { get; set; }

            [JsonPropertyName("V27AUList.")]
            public List<string> V27AUList { get; set; }

            [JsonPropertyName("v26N.")]
            public string V26N { get; set; }

            [JsonPropertyName("v26U.")]
            public string V26U { get; set; }

            [JsonPropertyName("v26AU.")]
            public string V26AU { get; set; }

            [JsonPropertyName("v28.")]
            public string V28 { get; set; }

            [JsonPropertyName("v28b.")]
            public List<object> V28b { get; set; }

            [JsonPropertyName("v29.")]
            public List<string> V29 { get; set; }

            [JsonPropertyName("v32List.")]
            public List<object> V32List { get; set; }

            [JsonPropertyName("v30.")]
            public List<string> V30 { get; set; }

            [JsonPropertyName("v32A.")]
            public List<object> V32A { get; set; }

            [JsonPropertyName("v32B.")]
            public List<object> V32B { get; set; }

            [JsonPropertyName("v32C.")]
            public List<string> V32C { get; set; }

            [JsonPropertyName("v32ED.")]
            public List<string> V32ED { get; set; }

            [JsonPropertyName("v31.")]
            public string V31 { get; set; }

            [JsonPropertyName("v33.")]
            public string V33 { get; set; }

            [JsonPropertyName("v34.")]
            public string V34 { get; set; }

            [JsonPropertyName("v35.")]
            public string V35 { get; set; }

            [JsonPropertyName("v36.")]
            public string V36 { get; set; }

            [JsonPropertyName("v37.")]
            public string V37 { get; set; }

            [JsonPropertyName("v38.")]
            public string V38 { get; set; }

            [JsonPropertyName("v39.")]
            public string V39 { get; set; }

            [JsonPropertyName("v39_avg.")]
            public string V39Avg { get; set; }

            [JsonPropertyName("v40.")]
            public string V40 { get; set; }

            [JsonPropertyName("v40_avg.")]
            public string V40Avg { get; set; }

            [JsonPropertyName("v41.")]
            public string V41 { get; set; }

            [JsonPropertyName("v42.")]
            public string V42 { get; set; }

            [JsonPropertyName("v43.")]
            public string V43 { get; set; }

            [JsonPropertyName("v44m.")]
            public string V44m { get; set; }

            [JsonPropertyName("v45.")]
            public string V45 { get; set; }

            [JsonPropertyName("v45_sum.")]
            public string V45Sum { get; set; }

            [JsonPropertyName("v46m.")]
            public string V46m { get; set; }

            [JsonPropertyName("v47.")]
            public string V47 { get; set; }

            [JsonPropertyName("v48.")]
            public string V48 { get; set; }

            [JsonPropertyName("v49.")]
            public string V49 { get; set; }

            [JsonPropertyName("v50.")]
            public string V50 { get; set; }

            [JsonPropertyName("v51.")]
            public string V51 { get; set; }

            [JsonPropertyName("v52.")]
            public string V52 { get; set; }

            [JsonPropertyName("v53.")]
            public string V53 { get; set; }

            [JsonPropertyName("v54.")]
            public string V54 { get; set; }

            [JsonPropertyName("v55.")]
            public string V55 { get; set; }

            [JsonPropertyName("v56m.")]
            public string V56m { get; set; }

            [JsonPropertyName("v57m.")]
            public string V57m { get; set; }

            [JsonPropertyName("v59m.")]
            public string V59m { get; set; }

            [JsonPropertyName("v61m.")]
            public string V61m { get; set; }

            [JsonPropertyName("v62m.")]
            public string V62m { get; set; }

            [JsonPropertyName("v63m.")]
            public string V63m { get; set; }

            [JsonPropertyName("v63_G1m.")]
            public string V63G1m { get; set; }

            [JsonPropertyName("vG6.")]
            public string VG6 { get; set; }

            [JsonPropertyName("v63_solar.")]
            public string V63Solar { get; set; }

            [JsonPropertyName("v63_pv.")]
            public string V63Pv { get; set; }

            [JsonPropertyName("v63_G1m_sum.")]
            public string V63G1mSum { get; set; }

            [JsonPropertyName("v63_H1.")]
            public string V63H1 { get; set; }

            [JsonPropertyName("v63_H2.")]
            public string V63H2 { get; set; }

            [JsonPropertyName("v63_H3.")]
            public string V63H3 { get; set; }

            [JsonPropertyName("v63_H3a.")]
            public string V63H3a { get; set; }

            [JsonPropertyName("v63_H3b.")]
            public string V63H3b { get; set; }

            [JsonPropertyName("v63_H4.")]
            public string V63H4 { get; set; }

            [JsonPropertyName("v63_H5.")]
            public string V63H5 { get; set; }

            [JsonPropertyName("v63_H6.")]
            public string V63H6 { get; set; }

            [JsonPropertyName("v63_H7.")]
            public string V63H7 { get; set; }

            [JsonPropertyName("v63_H7a.")]
            public string V63H7a { get; set; }

            [JsonPropertyName("v63_H8.")]
            public string V63H8 { get; set; }

            [JsonPropertyName("v63_H9.")]
            public string V63H9 { get; set; }

            [JsonPropertyName("v63_H10.")]
            public string V63H10 { get; set; }

            [JsonPropertyName("v63_H11.")]
            public string V63H11 { get; set; }

            [JsonPropertyName("v63_H13.")]
            public string V63H13 { get; set; }

            [JsonPropertyName("v63_H14.")]
            public string V63H14 { get; set; }

            [JsonPropertyName("v63_H15.")]
            public string V63H15 { get; set; }

            [JsonPropertyName("v63_H16.")]
            public string V63H16 { get; set; }

            [JsonPropertyName("v63_H17.")]
            public string V63H17 { get; set; }

            [JsonPropertyName("v63_G3m.")]
            public string V63G3m { get; set; }

            [JsonPropertyName("v63_G2m.")]
            public string V63G2m { get; set; }

            [JsonPropertyName("v63_G10m.")]
            public string V63G10m { get; set; }

            [JsonPropertyName("v64m.")]
            public string V64m { get; set; }

            [JsonPropertyName("v64m_sum.")]
            public string V64mSum { get; set; }

            [JsonPropertyName("v65m.")]
            public string V65m { get; set; }

            [JsonPropertyName("v66m.")]
            public string V66m { get; set; }

            [JsonPropertyName("v67m.")]
            public string V67m { get; set; }

            [JsonPropertyName("v68m.")]
            public string V68m { get; set; }

            [JsonPropertyName("v69m.")]
            public string V69m { get; set; }

            [JsonPropertyName("v70m.")]
            public string V70m { get; set; }

            [JsonPropertyName("v71m.")]
            public string V71m { get; set; }

            [JsonPropertyName("v72m.")]
            public string V72m { get; set; }

            [JsonPropertyName("v73m.")]
            public string V73m { get; set; }

            [JsonPropertyName("v76_inputFlag.")]
            public string V76InputFlag { get; set; }

            [JsonPropertyName("v7482.")]
            public List<string> V7482 { get; set; }

            [JsonPropertyName("v76_1.")]
            public string V761 { get; set; }

            [JsonPropertyName("v76a_1.")]
            public string V76a1 { get; set; }

            [JsonPropertyName("v76_2.")]
            public string V762 { get; set; }

            [JsonPropertyName("v76a_2.")]
            public string V76a2 { get; set; }

            [JsonPropertyName("v76_sum.")]
            public string V76Sum { get; set; }

            [JsonPropertyName("v83.")]
            public string V83 { get; set; }

            [JsonPropertyName("v84m.")]
            public string V84m { get; set; }

            [JsonPropertyName("v85.")]
            public string V85 { get; set; }

            [JsonPropertyName("v85_next.")]
            public string V85Next { get; set; }

            [JsonPropertyName("v86m.")]
            public string V86m { get; set; }

            [JsonPropertyName("v86m_tau.")]
            public string V86mTau { get; set; }

            [JsonPropertyName("v86m_alpha.")]
            public string V86mAlpha { get; set; }

            [JsonPropertyName("v86m_externalTemp.")]
            public string V86mExternalTemp { get; set; }

            [JsonPropertyName("v87m.")]
            public string V87m { get; set; }

            [JsonPropertyName("v88m.")]
            public string V88m { get; set; }

            [JsonPropertyName("v89m.")]
            public string V89m { get; set; }

            [JsonPropertyName("v90m.")]
            public string V90m { get; set; }

            [JsonPropertyName("v91.")]
            public string V91 { get; set; }

            [JsonPropertyName("v92m.")]
            public string V92m { get; set; }

            [JsonPropertyName("tempAdj.")]
            public string TempAdj { get; set; }

            [JsonPropertyName("v93m.")]
            public string V93m { get; set; }

            [JsonPropertyName("v94.")]
            public string V94 { get; set; }

            [JsonPropertyName("v95.")]
            public string V95 { get; set; }

            [JsonPropertyName("v96.")]
            public string V96 { get; set; }

            [JsonPropertyName("v97.")]
            public string V97 { get; set; }

            [JsonPropertyName("v97a.")]
            public string V97a { get; set; }

            [JsonPropertyName("v98m.")]
            public string V98m { get; set; }

            [JsonPropertyName("v98.")]
            public string V98 { get; set; }

            [JsonPropertyName("v99.")]
            public string V99 { get; set; }

            [JsonPropertyName("v201.")]
            public string V201 { get; set; }

            [JsonPropertyName("v202.")]
            public string V202 { get; set; }

            [JsonPropertyName("v203.")]
            public string V203 { get; set; }

            [JsonPropertyName("v204.")]
            public string V204 { get; set; }

            [JsonPropertyName("v205.")]
            public string V205 { get; set; }

            [JsonPropertyName("v206.")]
            public string V206 { get; set; }

            [JsonPropertyName("v207.")]
            public string V207 { get; set; }

            [JsonPropertyName("v208.")]
            public string V208 { get; set; }

            [JsonPropertyName("v209.")]
            public string V209 { get; set; }

            [JsonPropertyName("v210.")]
            public string V210 { get; set; }

            [JsonPropertyName("v64.")]
            public string V64 { get; set; }

            [JsonPropertyName("v211_sum.")]
            public string V211Sum { get; set; }

            [JsonPropertyName("v213_sum.")]
            public string V213Sum { get; set; }

            [JsonPropertyName("v211m.")]
            public string V211m { get; set; }

            [JsonPropertyName("CPSUFlag_m.")]
            public string CPSUFlagM { get; set; }

            [JsonPropertyName("CPSUFlag_sm.")]
            public string CPSUFlagSm { get; set; }

            [JsonPropertyName("CPSUFlag_wa.")]
            public string CPSUFlagWa { get; set; }

            [JsonPropertyName("v215m.")]
            public string V215m { get; set; }

            [JsonPropertyName("v215_sum.")]
            public string V215Sum { get; set; }

            [JsonPropertyName("v216.")]
            public string V216 { get; set; }

            [JsonPropertyName("v217.")]
            public string V217 { get; set; }

            [JsonPropertyName("v219.")]
            public string V219 { get; set; }

            [JsonPropertyName("v219_sum.")]
            public string V219Sum { get; set; }

            [JsonPropertyName("v221.")]
            public string V221 { get; set; }

            [JsonPropertyName("v221_sum.")]
            public string V221Sum { get; set; }

            [JsonPropertyName("v230a.")]
            public string V230a { get; set; }

            [JsonPropertyName("v230b.")]
            public string V230b { get; set; }

            [JsonPropertyName("v230c.")]
            public string V230c { get; set; }

            [JsonPropertyName("v230d.")]
            public string V230d { get; set; }

            [JsonPropertyName("v230e.")]
            public string V230e { get; set; }

            [JsonPropertyName("v230f.")]
            public string V230f { get; set; }

            [JsonPropertyName("v230g.")]
            public string V230g { get; set; }

            [JsonPropertyName("v230h.")]
            public string V230h { get; set; }

            [JsonPropertyName("v231.")]
            public string V231 { get; set; }

            [JsonPropertyName("v232.")]
            public string V232 { get; set; }

            [JsonPropertyName("v233.")]
            public string V233 { get; set; }

            [JsonPropertyName("v234.")]
            public string V234 { get; set; }

            [JsonPropertyName("v235.")]
            public string V235 { get; set; }

            [JsonPropertyName("v235a.")]
            public string V235a { get; set; }

            [JsonPropertyName("v238.")]
            public string V238 { get; set; }

            [JsonPropertyName("v240.")]
            public string V240 { get; set; }

            [JsonPropertyName("v240k.")]
            public string V240k { get; set; }

            [JsonPropertyName("v240p.")]
            public string V240p { get; set; }

            [JsonPropertyName("v241.")]
            public string V241 { get; set; }

            [JsonPropertyName("v241k.")]
            public string V241k { get; set; }

            [JsonPropertyName("v241p.")]
            public string V241p { get; set; }

            [JsonPropertyName("v242.")]
            public string V242 { get; set; }

            [JsonPropertyName("v242k.")]
            public string V242k { get; set; }

            [JsonPropertyName("v242p.")]
            public string V242p { get; set; }

            [JsonPropertyName("v243.")]
            public string V243 { get; set; }

            [JsonPropertyName("v244.")]
            public string V244 { get; set; }

            [JsonPropertyName("v245.")]
            public string V245 { get; set; }

            [JsonPropertyName("v245k.")]
            public string V245k { get; set; }

            [JsonPropertyName("v245p.")]
            public string V245p { get; set; }

            [JsonPropertyName("v246.")]
            public string V246 { get; set; }

            [JsonPropertyName("v246k.")]
            public string V246k { get; set; }

            [JsonPropertyName("v246p.")]
            public string V246p { get; set; }

            [JsonPropertyName("v247.")]
            public string V247 { get; set; }

            [JsonPropertyName("v247k.")]
            public string V247k { get; set; }

            [JsonPropertyName("v247p.")]
            public string V247p { get; set; }

            [JsonPropertyName("v248.")]
            public string V248 { get; set; }

            [JsonPropertyName("v248K.")]
            public string V248K { get; set; }

            [JsonPropertyName("v248P.")]
            public string V248P { get; set; }

            [JsonPropertyName("v249_SAP.")]
            public List<string> V249SAP { get; set; }

            [JsonPropertyName("v250.")]
            public string V250 { get; set; }

            [JsonPropertyName("v250k.")]
            public string V250k { get; set; }

            [JsonPropertyName("v250p.")]
            public string V250p { get; set; }

            [JsonPropertyName("v251.")]
            public string V251 { get; set; }

            [JsonPropertyName("v252_SAP.")]
            public List<string> V252SAP { get; set; }

            [JsonPropertyName("v253.")]
            public string V253 { get; set; }

            [JsonPropertyName("v254.")]
            public string V254 { get; set; }

            [JsonPropertyName("v255.")]
            public string V255 { get; set; }

            [JsonPropertyName("v256.")]
            public string V256 { get; set; }

            [JsonPropertyName("v257.")]
            public string V257 { get; set; }

            [JsonPropertyName("sapValue.")]
            public string SapValue { get; set; }

            [JsonPropertyName("sapBand.")]
            public string SapBand { get; set; }

            [JsonPropertyName("v258.")]
            public string V258 { get; set; }

            [JsonPropertyName("v261.")]
            public string V261 { get; set; }

            [JsonPropertyName("v261k.")]
            public string V261k { get; set; }

            [JsonPropertyName("v261f.")]
            public string V261f { get; set; }

            [JsonPropertyName("v262.")]
            public string V262 { get; set; }

            [JsonPropertyName("v262k.")]
            public string V262k { get; set; }

            [JsonPropertyName("v262f.")]
            public string V262f { get; set; }

            [JsonPropertyName("v263.")]
            public string V263 { get; set; }

            [JsonPropertyName("v263k.")]
            public string V263k { get; set; }

            [JsonPropertyName("v263f.")]
            public string V263f { get; set; }

            [JsonPropertyName("v264.")]
            public string V264 { get; set; }

            [JsonPropertyName("v264_w.")]
            public string V264W { get; set; }

            [JsonPropertyName("v264_s.")]
            public string V264S { get; set; }

            [JsonPropertyName("v264k.")]
            public string V264k { get; set; }

            [JsonPropertyName("v264k_w.")]
            public string V264kW { get; set; }

            [JsonPropertyName("v264k_s.")]
            public string V264kS { get; set; }

            [JsonPropertyName("v264f.")]
            public string V264f { get; set; }

            [JsonPropertyName("v264f_w.")]
            public string V264fW { get; set; }

            [JsonPropertyName("v264f_s.")]
            public string V264fS { get; set; }

            [JsonPropertyName("v265.")]
            public string V265 { get; set; }

            [JsonPropertyName("v266.")]
            public string V266 { get; set; }

            [JsonPropertyName("v266k.")]
            public string V266k { get; set; }

            [JsonPropertyName("v266f.")]
            public string V266f { get; set; }

            [JsonPropertyName("v267.")]
            public string V267 { get; set; }

            [JsonPropertyName("v267k.")]
            public string V267k { get; set; }

            [JsonPropertyName("v267f.")]
            public string V267f { get; set; }

            [JsonPropertyName("v268.")]
            public string V268 { get; set; }

            [JsonPropertyName("v268k.")]
            public string V268k { get; set; }

            [JsonPropertyName("v268f.")]
            public string V268f { get; set; }

            [JsonPropertyName("v269.")]
            public string V269 { get; set; }

            [JsonPropertyName("v269k.")]
            public string V269k { get; set; }

            [JsonPropertyName("v269f.")]
            public string V269f { get; set; }

            [JsonPropertyName("v269h.")]
            public string V269h { get; set; }

            [JsonPropertyName("v269w.")]
            public string V269w { get; set; }

            [JsonPropertyName("v269wk.")]
            public string V269wk { get; set; }

            [JsonPropertyName("v269wf.")]
            public string V269wf { get; set; }

            [JsonPropertyName("v269hf.")]
            public string V269hf { get; set; }

            [JsonPropertyName("v269hk.")]
            public string V269hk { get; set; }

            [JsonPropertyName("v269c.")]
            public string V269c { get; set; }

            [JsonPropertyName("v269cf.")]
            public string V269cf { get; set; }

            [JsonPropertyName("v269ck.")]
            public string V269ck { get; set; }

            [JsonPropertyName("v270.")]
            public string V270 { get; set; }

            [JsonPropertyName("v271.")]
            public string V271 { get; set; }

            [JsonPropertyName("v272.")]
            public string V272 { get; set; }

            [JsonPropertyName("v273.")]
            public string V273 { get; set; }

            [JsonPropertyName("v274.")]
            public string V274 { get; set; }

            [JsonPropertyName("eiValue.")]
            public string EiValue { get; set; }

            [JsonPropertyName("eiBand.")]
            public string EiBand { get; set; }

            [JsonPropertyName("vpe261.")]
            public string Vpe261 { get; set; }

            [JsonPropertyName("vpe261k.")]
            public string Vpe261k { get; set; }

            [JsonPropertyName("vpe261f.")]
            public string Vpe261f { get; set; }

            [JsonPropertyName("vpe262.")]
            public string Vpe262 { get; set; }

            [JsonPropertyName("vpe262k.")]
            public string Vpe262k { get; set; }

            [JsonPropertyName("vpe262f.")]
            public string Vpe262f { get; set; }

            [JsonPropertyName("vpe263.")]
            public string Vpe263 { get; set; }

            [JsonPropertyName("vpe263k.")]
            public string Vpe263k { get; set; }

            [JsonPropertyName("vpe263f.")]
            public string Vpe263f { get; set; }

            [JsonPropertyName("vpe264.")]
            public string Vpe264 { get; set; }

            [JsonPropertyName("vpe264_w.")]
            public string Vpe264W { get; set; }

            [JsonPropertyName("vpe264_s.")]
            public string Vpe264S { get; set; }

            [JsonPropertyName("vpe264k.")]
            public string Vpe264k { get; set; }

            [JsonPropertyName("vpe264k_w.")]
            public string Vpe264kW { get; set; }

            [JsonPropertyName("vpe264k_s.")]
            public string Vpe264kS { get; set; }

            [JsonPropertyName("vpe264f.")]
            public string Vpe264f { get; set; }

            [JsonPropertyName("vpe264f_w.")]
            public string Vpe264fW { get; set; }

            [JsonPropertyName("vpe264f_s.")]
            public string Vpe264fS { get; set; }

            [JsonPropertyName("vpe265.")]
            public string Vpe265 { get; set; }

            [JsonPropertyName("vpe266.")]
            public string Vpe266 { get; set; }

            [JsonPropertyName("vpe266k.")]
            public string Vpe266k { get; set; }

            [JsonPropertyName("vpe266f.")]
            public string Vpe266f { get; set; }

            [JsonPropertyName("vpe267.")]
            public string Vpe267 { get; set; }

            [JsonPropertyName("vpe267k.")]
            public string Vpe267k { get; set; }

            [JsonPropertyName("vpe267f.")]
            public string Vpe267f { get; set; }

            [JsonPropertyName("vpe268.")]
            public string Vpe268 { get; set; }

            [JsonPropertyName("vpe268k.")]
            public string Vpe268k { get; set; }

            [JsonPropertyName("vpe268f.")]
            public string Vpe268f { get; set; }

            [JsonPropertyName("vpe269.")]
            public string Vpe269 { get; set; }

            [JsonPropertyName("vpe269k.")]
            public string Vpe269k { get; set; }

            [JsonPropertyName("vpe269f.")]
            public string Vpe269f { get; set; }

            [JsonPropertyName("vpe269w.")]
            public string Vpe269w { get; set; }

            [JsonPropertyName("vpe269wk.")]
            public string Vpe269wk { get; set; }

            [JsonPropertyName("vpe269wf.")]
            public string Vpe269wf { get; set; }

            [JsonPropertyName("vpe269h.")]
            public string Vpe269h { get; set; }

            [JsonPropertyName("vpe269hk.")]
            public string Vpe269hk { get; set; }

            [JsonPropertyName("vpe269hf.")]
            public string Vpe269hf { get; set; }

            [JsonPropertyName("vpe269c.")]
            public string Vpe269c { get; set; }

            [JsonPropertyName("vpe269ck.")]
            public string Vpe269ck { get; set; }

            [JsonPropertyName("vpe269cf.")]
            public string Vpe269cf { get; set; }

            [JsonPropertyName("vpe272.")]
            public string Vpe272 { get; set; }

            [JsonPropertyName("vpe273.")]
            public string Vpe273 { get; set; }

            [JsonPropertyName("eva_m_cost.")]
            public string EvaMCost { get; set; }

            [JsonPropertyName("eva_m_emission.")]
            public string EvaMEmission { get; set; }

            [JsonPropertyName("eva_wa_cost.")]
            public string EvaWaCost { get; set; }

            [JsonPropertyName("eva_wa_emission.")]
            public string EvaWaEmission { get; set; }

            [JsonPropertyName("v272a.")]
            public string V272a { get; set; }

            [JsonPropertyName("v272b.")]
            public string V272b { get; set; }

            [JsonPropertyName("v272c.")]
            public string V272c { get; set; }

            [JsonPropertyName("TER.")]
            public string TER { get; set; }

            [JsonPropertyName("country.")]
            public string Country { get; set; }

            [JsonPropertyName("dataType.")]
            public string DataType { get; set; }

            [JsonPropertyName("builtForm.")]
            public string BuiltForm { get; set; }

            [JsonPropertyName("floorArea.")]
            public string FloorArea { get; set; }

            [JsonPropertyName("SCTFlag.")]
            public string SCTFlag { get; set; }

            [JsonPropertyName("fuelName.")]
            public string FuelName { get; set; }

            [JsonPropertyName("fuelFactor.")]
            public string FuelFactor { get; set; }

            [JsonPropertyName("DER.")]
            public string DER { get; set; }

            [JsonPropertyName("DERCheck.")]
            public string DERCheck { get; set; }

            [JsonPropertyName("FEEAppliesFlag.")]
            public string FEEAppliesFlag { get; set; }

            [JsonPropertyName("TFEE.")]
            public string TFEE { get; set; }

            [JsonPropertyName("DFEE.")]
            public string DFEE { get; set; }

            [JsonPropertyName("DFEECheck.")]
            public string DFEECheck { get; set; }

            [JsonPropertyName("uValueList.")]
            public List<string> UValueList { get; set; }

            [JsonPropertyName("thermalBridging.")]
            public string ThermalBridging { get; set; }

            [JsonPropertyName("Q50.")]
            public string Q50 { get; set; }

            [JsonPropertyName("Q50AssumeFlag.")]
            public string Q50AssumeFlag { get; set; }

            [JsonPropertyName("Q50Check.")]
            public string Q50Check { get; set; }

            [JsonPropertyName("HasSecondMainFlag.")]
            public string HasSecondMainFlag { get; set; }

            [JsonPropertyName("HeatingDataSource_M.")]
            public string HeatingDataSourceM { get; set; }

            [JsonPropertyName("HeatingCategory_M.")]
            public string HeatingCategoryM { get; set; }

            [JsonPropertyName("HeatingEfficiency_M.")]
            public string HeatingEfficiencyM { get; set; }

            [JsonPropertyName("MainHeatingCheck_M.")]
            public string MainHeatingCheckM { get; set; }

            [JsonPropertyName("MainHeatingDescriptionDetail_M.")]
            public string MainHeatingDescriptionDetailM { get; set; }

            [JsonPropertyName("MainHeatingBoilerType_M.")]
            public string MainHeatingBoilerTypeM { get; set; }

            [JsonPropertyName("MicroCHPFlag_M.")]
            public string MicroCHPFlagM { get; set; }

            [JsonPropertyName("HeatingEfficiencyMin_M.")]
            public string HeatingEfficiencyMinM { get; set; }

            [JsonPropertyName("HeatingCateogry_SE.")]
            public string HeatingCateogrySE { get; set; }

            [JsonPropertyName("HeatingEfficiency_SE.")]
            public string HeatingEfficiencySE { get; set; }

            [JsonPropertyName("HeatingDescription_SE.")]
            public string HeatingDescriptionSE { get; set; }

            [JsonPropertyName("HeatingEfficiencyMin_SE.")]
            public string HeatingEfficiencyMinSE { get; set; }

            [JsonPropertyName("SecondaryHeatingCheck.")]
            public string SecondaryHeatingCheck { get; set; }

            [JsonPropertyName("cylinderLoss.")]
            public string CylinderLoss { get; set; }

            [JsonPropertyName("controlName_M.")]
            public string ControlNameM { get; set; }

            [JsonPropertyName("controlCheck_M.")]
            public string ControlCheckM { get; set; }

            [JsonPropertyName("isBoilerFlag_WA.")]
            public string IsBoilerFlagWA { get; set; }

            [JsonPropertyName("cylinderThermostatAvailableFlag_WA.")]
            public string CylinderThermostatAvailableFlagWA { get; set; }

            [JsonPropertyName("OmitBoilerInterlockFlag.")]
            public string OmitBoilerInterlockFlag { get; set; }

            [JsonPropertyName("HeatPumpWaterFlag.")]
            public string HeatPumpWaterFlag { get; set; }

            [JsonPropertyName("boilerInterlock.")]
            public string BoilerInterlock { get; set; }

            [JsonPropertyName("boilerInterlockCheck.")]
            public string BoilerInterlockCheck { get; set; }

            [JsonPropertyName("seperateControlCheck.")]
            public string SeperateControlCheck { get; set; }

            [JsonPropertyName("cylinderThermostatCheck.")]
            public string CylinderThermostatCheck { get; set; }

            [JsonPropertyName("pipeworkAppliesFlag.")]
            public string PipeworkAppliesFlag { get; set; }

            [JsonPropertyName("pipeworkV59ZeroFlag.")]
            public string PipeworkV59ZeroFlag { get; set; }

            [JsonPropertyName("pipework.")]
            public string Pipework { get; set; }

            [JsonPropertyName("pipeworkCheck.")]
            public string PipeworkCheck { get; set; }

            [JsonPropertyName("solarAppliesFlag.")]
            public string SolarAppliesFlag { get; set; }

            [JsonPropertyName("lightPercentage.")]
            public string LightPercentage { get; set; }

            [JsonPropertyName("lightPercentageMin.")]
            public string LightPercentageMin { get; set; }

            [JsonPropertyName("lightCheck.")]
            public string LightCheck { get; set; }

            [JsonPropertyName("ventilationDescription.")]
            public string VentilationDescription { get; set; }

            [JsonPropertyName("region.")]
            public string Region { get; set; }

            [JsonPropertyName("appendixPAppliesFlag.")]
            public string AppendixPAppliesFlag { get; set; }

            [JsonPropertyName("keyFeatureList.")]
            public List<string> KeyFeatureList { get; set; }

            [JsonPropertyName("coolingFlag.")]
            public string CoolingFlag { get; set; }

            [JsonPropertyName("v100.")]
            public string V100 { get; set; }

            [JsonPropertyName("v101.")]
            public string V101 { get; set; }

            [JsonPropertyName("v102.")]
            public string V102 { get; set; }

            [JsonPropertyName("v103_73.")]
            public string V10373 { get; set; }

            [JsonPropertyName("v103_83.")]
            public string V10383 { get; set; }

            [JsonPropertyName("v103.")]
            public string V103 { get; set; }

            [JsonPropertyName("v103a.")]
            public string V103a { get; set; }

            [JsonPropertyName("v104.")]
            public string V104 { get; set; }

            [JsonPropertyName("v104_sum.")]
            public string V104Sum { get; set; }

            [JsonPropertyName("v105.")]
            public string V105 { get; set; }

            [JsonPropertyName("v106.")]
            public string V106 { get; set; }

            [JsonPropertyName("v107.")]
            public string V107 { get; set; }

            [JsonPropertyName("v107_sum.")]
            public string V107Sum { get; set; }

            [JsonPropertyName("v108.")]
            public string V108 { get; set; }

            [JsonPropertyName("v109.")]
            public string V109 { get; set; }

            [JsonPropertyName("postcode.")]
            public string Postcode { get; set; }

            [JsonPropertyName("date_assessment.")]
            public string DateAssessment { get; set; }

            [JsonPropertyName("assessmentType.")]
            public string AssessmentType { get; set; }

            [JsonPropertyName("tenure.")]
            public string Tenure { get; set; }

            [JsonPropertyName("transactionType.")]
            public string TransactionType { get; set; }

            [JsonPropertyName("relatedPartyDisclosure.")]
            public string RelatedPartyDisclosure { get; set; }

            [JsonPropertyName("dwellingType.")]
            public string DwellingType { get; set; }

            [JsonPropertyName("detachType.")]
            public string DetachType { get; set; }

            [JsonPropertyName("dimensionList.")]
            public List<string> DimensionList { get; set; }

            [JsonPropertyName("livingArea.")]
            public string LivingArea { get; set; }

            [JsonPropertyName("frontOfDwelling.")]
            public string FrontOfDwelling { get; set; }

            [JsonPropertyName("openingTypeListA.")]
            public List<string> OpeningTypeListA { get; set; }

            [JsonPropertyName("openingTypeListB.")]
            public List<string> OpeningTypeListB { get; set; }

            [JsonPropertyName("openingList.")]
            public List<string> OpeningList { get; set; }

            [JsonPropertyName("overshading.")]
            public string Overshading { get; set; }

            [JsonPropertyName("heatLossList.")]
            public List<string> HeatLossList { get; set; }

            [JsonPropertyName("thermalBridgeType.")]
            public string ThermalBridgeType { get; set; }

            [JsonPropertyName("thermalBridgeList.")]
            public List<string> ThermalBridgeList { get; set; }

            [JsonPropertyName("thermalMass.")]
            public string ThermalMass { get; set; }

            [JsonPropertyName("pressureTest.")]
            public string PressureTest { get; set; }

            [JsonPropertyName("ventilation.")]
            public string Ventilation { get; set; }

            [JsonPropertyName("ventilationList.")]
            public List<object> VentilationList { get; set; }

            [JsonPropertyName("numberOfChimney.")]
            public string NumberOfChimney { get; set; }

            [JsonPropertyName("numberOfOpenflue.")]
            public string NumberOfOpenflue { get; set; }

            [JsonPropertyName("numberOfIntermittentFans.")]
            public string NumberOfIntermittentFans { get; set; }

            [JsonPropertyName("numberOfPassiveStacks.")]
            public string NumberOfPassiveStacks { get; set; }

            [JsonPropertyName("numberOfSidesSheltered.")]
            public string NumberOfSidesSheltered { get; set; }

            [JsonPropertyName("mainHeatingList.")]
            public List<string> MainHeatingList { get; set; }

            [JsonPropertyName("mainControlList.")]
            public List<string> MainControlList { get; set; }

            [JsonPropertyName("secondaryHeatingList.")]
            public List<string> SecondaryHeatingList { get; set; }

            [JsonPropertyName("spaceCoolingList.")]
            public List<string> SpaceCoolingList { get; set; }

            [JsonPropertyName("waterHeatingList.")]
            public List<string> WaterHeatingList { get; set; }

            [JsonPropertyName("waterUse.")]
            public string WaterUse { get; set; }

            [JsonPropertyName("electricityTariff.")]
            public string ElectricityTariff { get; set; }

            [JsonPropertyName("smokeControlArea.")]
            public string SmokeControlArea { get; set; }

            [JsonPropertyName("conservatory.")]
            public string Conservatory { get; set; }

            [JsonPropertyName("photovoltics.")]
            public string Photovoltics { get; set; }

            [JsonPropertyName("terrainType.")]
            public string TerrainType { get; set; }

            [JsonPropertyName("windTurbine.")]
            public string WindTurbine { get; set; }

            [JsonPropertyName("totalFixedLighting.")]
            public string TotalFixedLighting { get; set; }

            [JsonPropertyName("lowEnergyFixedLighting.")]
            public string LowEnergyFixedLighting { get; set; }

            [JsonPropertyName("appendixQList.")]
            public List<object> AppendixQList { get; set; }
        
    }
}

