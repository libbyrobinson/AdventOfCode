const input = [
  "fmhsnr fpmz bfgcms kptrg nrvjmfb fvqhc xnjx rdhljms pqqxxn mpkk ctvdb sdjnb mht pfqjpf vnn mcgs tsvrr htnhq mppgst dktk kxqpgz blgbtz knzghq ksgpjv gxf jcqbsv xxthxs vccmfr ksbnxq xpmx kgd jzn bshlm srv nrm bzczpk vbfqs mkpmz pnpfjb gmsds tzlnd scsnf ddsz bbfkbl xdblc ktpbgdn pbrds pmvlzl qpqtsn gkzgj fmsf xzfj qgvkhjb fvqmjdl jmzk klkdpk lgvjd mhbzd mrvp bcss gjcvms rscgs qnzbpx phn fkcmf pssnm nkbq gkjh kjmxcb pclxz nkxn lscrnr vmc nbn jtkx bzhfdv nrmqlv hdqkqhh hmtkfnq hsqh pdnqm ckxrpj fqxdnm pfmfh gsfx dmrnl qfnbft ptjd (contains dairy, shellfish, eggs)",
  "qpkhl pfmfh fhbkt xdblc trrqf tfrlh qtltm dxlzf fvqmjdl gctpx hdqkqhh lxjmhz hvqxq ndfb rsnmm cnm hvtnftb rqrb xnjx vmhnvv kptrg pssnm ndnvm fgpkgp fdgt rqhrnm bzczpk ktpbgdn vnn jqdtgp mnrmrl bgkh sfsjpk qxqcg rdhljms pnpfjb fpmz mcgs qfnbft lscrnr jzn klkdpk bfgcms nsfkkx vmhsj fkcmf kzlknls (contains shellfish)",
  "ghmtfn knzghq jhl lrk fvqhc bnfcvc kngjc nbn bshlm vnn hmtkfnq mrvp jqrvm gqgds kxqpgz hzhzdtd rscgs bzhfdv ndfb nrm xnkh vmc htnhq jcqbsv ptjd xpmx jdkxx fkcmf fqxdnm gkzgj kkffssg ddzvfvq pmvlzl mkpmz rnpll mjcrg ktpbgdn sdjnb pttsn jtkx xsxnr sfsjpk sxlnzm fpmz kfbpzd bcss kghrr gnmsc lqvg tflck sfhb fmsf pvvds kmmtz xxthxs hvtnftb xzfj lxjmhz vmhsj lbhl gkjh pnpfjb qgvkhjb ndnvm hktlnb mltbpl qxqcg rdhljms ddsz mnrmrl cxltld szgjf bfgcms hvqxq nrmqlv rsnmm mdfnq (contains dairy, peanuts)",
  "znjlq fvcqs nbn hpczjn qpkhl ddsz xpmx cxltld jhl rnpll fkcmf jkvsmc ktpbgdn vnn fgpkgp sdjnb fjkbf kzlknls mrvp bnxp tflck pclxz ptjd dqqnr pttsn kpkrmx phvqslms vbfqs bgnqdk lbhl qgvkhjb kxqpgz msgzx fhbkt dxlzf nkbq vccmfr tzlnd ndfb sfhb fvqhc gtrffv mcgs fpmz xzfj nsfkkx rhbfl sfsjpk tfgrk xdxdlsh tcp qbgkhj qfnbft mltbpl hvqxq htnhq knzghq hdqkqhh vfjb kgd kngjc xnkh kghrr nrm rqrb mdfnq gqgds pmvlzl xxthxs gxf bzhfdv ksgpjv dktk pssnm pfmfh mpkk gjcvms dmrnl qhgcvmm tsvrr zgnxh pnpfjb mpclb jsznqq hrnq rdhljms fdgt (contains dairy, eggs, wheat)",
  "mrvp chhct rhbfl mdfnq pmvlzl bgnqdk bnfcvc jtkx kxbg ndfb ptjd pfmfh zmxmr hktlnb dxlzf xdxdlsh rscgs rqlslh mpkk pclxz qgjfx fkcmf gqgds sxlnzm hdqkqhh mnrmrl nkxn tcp pbrds hscbd nbtgf pdnqm sfhb jqrvm scsnf lqvg gkjh fgpkgp qhgcvmm lxjmhz tsvrr tzlnd bfgcms hzhzdtd kfbpzd vmhnvv qpqtsn mmkq lrk nsfkkx jqdtgp gpmpf pttsn jzn dgv sdjnb ksgpjv xzfj rdhljms ghmtfn tflck mpclb bzhfdv ktpbgdn sqbvb xxthxs pfqjpf (contains dairy, shellfish)",
  "szcfx ndfb fkcmf scsnf gsfx fhbkt jcqbsv tfrlh fmsf jdkxx mkpmz mcgs bzczpk zgnxh htnhq qxqcg mnrmrl rqrb chhct gnmsc hdqkqhh nrmqlv xzfj ktpbgdn rdhljms gjcvms xdxdlsh hnnjms gqgds szgjf bfgcms jkvsmc rqlslh qhgcvmm dmrnl cnknqf sxlnzm kgd vbfqs fvqhc jtkx (contains dairy, sesame, fish)",
  "hktlnb fqxdnm lbhl kfbpzd psscnhr lscrnr mpclb rhbfl pnpfjb htnhq fvqhc rdhljms hdqkqhh tfgrk kxqpgz vccmfr kxbg jhl bshlm hnnjms jsznqq jtkx bbfkbl znjlq fpmz tcp zth xnjx sxlnzm nrm jqrvm fkcmf mpkk fvqmjdl scsnf gmsds mdfnq pkptv qtltm hscbd cnm hmtkfnq fvcqs bzczpk ndfb qxqcg gsfx xnkh chcnqzx ksbnxq kzlknls gjcvms ddzvfvq bgkh xzfj bmgg cnknqf pttsn gxf xdblc dmrnl xxthxs gnmsc dxlzf jcqbsv lgvjd rmdmc qzffj ndnvm fhbkt bnfcvc bgnqdk vmhnvv qpqtsn bfgcms nkxn ksgpjv kmmtz (contains sesame)",
  "xnkh sfsjpk csfflg mrvp bfgcms lxjmhz bgnqdk szcfx hrnq jqdtgp lbhl chhct lqvg gpmpf hvqxq pbrds jtkx rqrb cnknqf qbgkhj pssnm bzczpk kxqpgz hdqkqhh phn htnhq hpczjn fdgt szgjf qnzbpx ndfb dqqnr tsvrr xzfj dgv rdhljms bzhfdv jhl mppgst kpkrmx vmhsj vfjb gtrffv scbhzv ghmtfn kxbg nkxn xsxnr trrqf kmmtz tfgrk fvqmjdl qzffj mdfnq dmrnl xlqxvn rhbfl vmhnvv pnpfjb xxthxs fqxdnm hnnjms kgd bgkh psscnhr ptjd pqhqv jkvsmc fmhsnr srv vccmfr ndnvm cnm rqlslh fhbkt vnn ktpbgdn hzhzdtd kghrr kfbpzd lrk (contains fish, eggs)",
  "bzczpk hdqkqhh tzlnd pvvds bgkh sdjnb bgnqdk vgcxss xdblc jqrvm kpkrmx hvqxq qhgcvmm mpclb pbrds rqhrnm hsqh fkcmf fvcqs sfhb pssnm lscrnr ktpbgdn pkptv ctvdb xzfj mmkq pqqxxn vbfqs mltbpl zth pnpfjb xnjx hrnq ndfb kzlknls hpczjn szcfx psscnhr jcqbsv qxqcg nrmqlv klkdpk gqgds rdhljms kptrg cnm pmvlzl nrm (contains soy, fish)",
  "hktlnb kmmtz cxltld mdfnq fkcmf xxthxs fdgt lgvjd pnpfjb dqqnr kpkrmx knzghq pqqxxn fhbkt szgjf jqrvm mjcrg ktpbgdn vfjb mrvp tflck ptjd sqbvb qxqcg rdhljms nkbq cnknqf tfrlh hdqkqhh nbtgf csfflg ghmtfn rxxmdp sfhb nbn jzn ctvdb ddsz mppgst pttsn jmzk pfqjpf mht dgv kxqpgz xnjx xzfj fvqmjdl kxbg qtltm gxf jkvsmc bfgcms hrnq rqlslh znjlq bcss bnfcvc gpmpf xnkh vnn rqhrnm rscgs phvqslms gkzgj rhbfl qhgcvmm hsqh mhbzd bzhfdv nrm kkffssg chhct kghrr srv qgvkhjb rsnmm ckxrpj ndnvm bgnqdk xdblc (contains sesame, shellfish, eggs)",
  "bnxp phvqslms qhgcvmm zmxmr jkvsmc hvtnftb hpczjn nrvjmfb tfrlh hdqkqhh cnm fvqmjdl pssnm kmmtz sqbvb vmhnvv kxbg xzfj gnmsc lbhl mrvp fhbkt jqrvm sxlnzm pfqjpf xdblc rdhljms kzlknls jqdtgp mpkk bbfkbl cnknqf jcqbsv rxxmdp hvqxq hnnjms scsnf pmvlzl kjmxcb bzczpk gmsds qnzbpx sdjnb gtrffv ksgpjv htnhq ktpbgdn fpmz ksbnxq kkffssg scmkv bcss dmrnl fqxdnm tsvrr bfgcms qzffj jsznqq dxlzf jmzk qgjfx ndfb pttsn fkcmf tfgrk vgcxss pqhqv (contains fish, soy)",
  "bzczpk pmvlzl jqrvm tzlnd xnkh bnfcvc rnpll hmtkfnq qbgkhj rdhljms vmhsj pqqxxn pttsn qpkhl jcqbsv xzfj tfrlh pfmfh dmrnl hpczjn ksbnxq mhbzd dqqnr fpmz lscrnr fdgt hdqkqhh qtltm nkxn fkcmf zgnxh ddsz qgvkhjb hrnq bshlm cxltld gkzgj dxlzf fvqhc kmmtz lrk bfgcms cnm rqhrnm gsfx jmzk jkvsmc lxjmhz bbfkbl pvvds gjcvms lqvg fjkbf mkpmz mht ktpbgdn szcfx bnxp jzn ndfb mpkk nbn csfflg (contains shellfish)",
  "bfgcms ckxrpj vmhnvv mcgs xzfj rdhljms ndfb pqqxxn nbtgf ktpbgdn jdkxx mmkq jcqbsv dktk klgbs qtltm tfgrk tsvrr hpczjn znjlq xlqxvn jmzk szcfx sqbvb qgvkhjb rxxmdp ndnvm hrnq vccmfr mht pfmfh pnpfjb fpmz pfqjpf pclxz nkbq vgcxss rnpll jkvsmc lbhl nkxn bnfcvc gqgds ksgpjv psscnhr xdxdlsh fkcmf hmtkfnq sdjnb bmgg phvqslms mhbzd dqqnr ghmtfn rqrb mrvp (contains sesame, shellfish)",
  "nrmqlv xpmx mmkq hdqkqhh klkdpk zmxmr ksgpjv ctvdb gxf tfgrk bzhfdv kmmtz vnn hrnq gmsds gkzgj rdhljms qtltm nbtgf nkxn qbgkhj rhbfl ddsz mjcrg xnjx bcss bnfcvc jdkxx ktpbgdn lqvg hpczjn fkcmf lscrnr gjcvms rnpll cxltld pbrds mdfnq xdblc mltbpl bnxp dqqnr tcp sfhb mkpmz xsxnr zth jqrvm qnzbpx gsfx cnknqf xzfj jzn kxbg qzffj dxlzf gkjh qgjfx bfgcms ghmtfn nrm jtkx srv sdjnb hzhzdtd fvcqs sxlnzm tflck scmkv pnpfjb cnm (contains sesame, dairy)",
  "dmrnl mht gkjh qzffj kptrg bbfkbl msgzx zth kxqpgz kghrr gsfx szgjf hnnjms pttsn lscrnr qgjfx pdnqm bfgcms mjcrg ktpbgdn xpmx fhbkt gqgds pbrds vgcxss htnhq fkcmf xzfj chhct nbtgf vfjb tzlnd nbn fmsf dgv cnm znjlq ddsz zgnxh gtrffv srv hktlnb mhbzd vmhnvv sxlnzm mnrmrl hzhzdtd ksbnxq mrvp pnpfjb jhl klkdpk bgnqdk pqhqv lgvjd qxqcg chcnqzx ddzvfvq tfrlh kngjc gkzgj sfhb kkffssg jcqbsv mdfnq xlqxvn ndfb bzhfdv jqdtgp ksgpjv qfnbft sdjnb nrm pclxz jdkxx xxthxs kjmxcb rmdmc ndnvm bnxp rxxmdp hdqkqhh mpkk rsnmm fjkbf gctpx lxjmhz hrnq qtltm mp bzczpk qnzbpx (contains fish, soy)",
  "bnxp pbrds klkdpk lqvg hnnjms kmmtz mpkk gqgds gsfx bnfcvc mht lgvjd qpqtsn bzczpk tfgrk rmdmc sqbvb bfgcms pfqjpf gnmsc lscrnr fkcmf ndfb hscbd xsxnr rnpll kxbg kxqpgz bgnqdk hdqkqhh blgbtz dgv bmgg vnn ckxrpj kpkrmx qbgkhj xzfj gctpx scsnf xdblc szgjf gtrffv klgbs zth mltbpl kkffssg xdxdlsh ktpbgdn jcqbsv fhbkt pkptv kngjc xlqxvn znjlq mnrmrl fvcqs ctvdb pnpfjb vfjb (contains soy)",
  "mnrmrl chcnqzx mjcrg mcgs gtrffv gmsds pvvds kngjc dgv bfgcms mltbpl mp sfsjpk qgjfx hrnq vmhnvv gqgds ptjd xxthxs phvqslms ktpbgdn bgkh rnpll klgbs phn bcss knzghq qfnbft mpkk rdhljms fkcmf ckxrpj gxf kmmtz jqrvm qxqcg kghrr kkffssg ndfb xdblc jmzk lrk hdqkqhh vmc csfflg pfqjpf rqrb mmkq hktlnb pdnqm xzfj jtkx ksgpjv pfmfh vnn nbtgf lgvjd pmvlzl rsnmm fdgt trrqf lscrnr sqbvb dmrnl fvqhc rscgs lbhl tfgrk bbfkbl xsxnr gkzgj ksbnxq (contains wheat, soy)",
  "dktk gnmsc bgnqdk rsnmm xxthxs gctpx klkdpk rqlslh xsxnr nbtgf fjkbf bcss ckxrpj bzhfdv ndfb tsvrr msgzx ddsz szcfx mp fmhsnr hmtkfnq jcqbsv fkcmf kptrg bnxp pnpfjb hnnjms bnfcvc vmc trrqf hvqxq xnjx jzn chhct rmdmc gxf cxltld ddzvfvq hdqkqhh jdkxx qbgkhj ptjd hrnq nkxn ktpbgdn lgvjd kjmxcb xpmx fqxdnm bshlm bgkh ctvdb kpkrmx nkbq qhgcvmm xzfj rdhljms jqdtgp bzczpk mdfnq fvcqs fgpkgp znjlq lrk qgjfx tfgrk mhbzd tflck lqvg mkpmz qzffj phvqslms (contains dairy, wheat)",
  "nkxn pbrds qhgcvmm rsnmm rdhljms ptjd dktk sfsjpk pdnqm lbhl fpmz ctvdb mcgs vmc hnnjms bmgg gjcvms jmzk znjlq rnpll scsnf klkdpk zgnxh sqbvb bbfkbl fdgt jqrvm rqrb chhct rqhrnm xpmx xsxnr mp xnjx zmxmr vmhnvv mdfnq ktpbgdn hrnq jcqbsv rqlslh mmkq pnpfjb dqqnr ksbnxq psscnhr vccmfr cnknqf pmvlzl qzffj nkbq xlqxvn sdjnb fmsf xzfj fmhsnr nrvjmfb ddsz bfgcms ndfb jdkxx zth fkcmf fjkbf sxlnzm (contains fish, dairy, sesame)",
  "rdhljms hsqh jsznqq bzhfdv bshlm xlqxvn jzn ckxrpj hmtkfnq lscrnr pkptv zmxmr ktpbgdn blgbtz scmkv klkdpk rhbfl hrnq dmrnl kkffssg tflck qbgkhj gmsds bcss jkvsmc vnn chhct lxjmhz xnjx fjkbf pvvds mkpmz mdfnq rqlslh qgjfx kfbpzd vbfqs kxqpgz knzghq bfgcms gxf srv sfhb xpmx fvqmjdl nrm znjlq fkcmf pnpfjb msgzx lrk szcfx scsnf lqvg scbhzv mp vfjb xnkh kzlknls ndfb ddzvfvq kxbg xzfj fdgt sxlnzm nrmqlv fvcqs vmhnvv tsvrr hnnjms ctvdb (contains dairy, soy, shellfish)",
  "jcqbsv ndfb pqhqv jtkx qfnbft xzfj bfgcms pqqxxn zmxmr kptrg jhl kngjc qnzbpx gnmsc rdhljms kxqpgz pttsn ktpbgdn mcgs ptjd lgvjd kxbg jqrvm bzczpk vmhnvv kkffssg sfsjpk fkcmf gjcvms phvqslms bnfcvc xpmx fvcqs bnxp sfhb pclxz vbfqs sxlnzm lxjmhz bbfkbl fvqmjdl mnrmrl dmrnl vmhsj jdkxx nbtgf psscnhr tsvrr sqbvb zth jmzk fmsf mjcrg dqqnr pnpfjb jkvsmc pssnm pbrds mkpmz qhgcvmm pkptv dktk rqlslh bmgg hmtkfnq phn cxltld lqvg fqxdnm mpclb cnknqf (contains soy, shellfish, dairy)",
  "gtrffv xzfj hscbd dqqnr xnjx rdhljms ksbnxq nsfkkx mppgst gsfx bgnqdk fgpkgp dxlzf blgbtz mrvp kptrg xlqxvn jqdtgp nrvjmfb mjcrg qhgcvmm cxltld bgkh pqqxxn hdqkqhh mht kpkrmx rhbfl rqhrnm mcgs hvtnftb ctvdb fkcmf pmvlzl tsvrr dgv pvvds gnmsc hrnq tfgrk hmtkfnq jzn vbfqs lxjmhz cnm bnfcvc nbn klgbs sqbvb fmhsnr phvqslms zmxmr xnkh tzlnd lqvg kjmxcb mpkk vmhnvv ddsz bfgcms kmmtz sfhb pnpfjb fjkbf qbgkhj hnnjms jcqbsv srv ndfb vmhsj fhbkt ghmtfn xdblc pqhqv mhbzd pdnqm (contains peanuts, sesame)",
  "csfflg xdxdlsh gjcvms fmhsnr fvqmjdl pbrds ghmtfn mpclb lgvjd gkzgj gnmsc mht rdhljms pqqxxn nkbq kgd qbgkhj chcnqzx jqdtgp cnm fkcmf xnkh sfhb qhgcvmm szgjf vccmfr rxxmdp bnxp mp scbhzv bzhfdv zth qgjfx mppgst sxlnzm qpqtsn hpczjn xzfj bnfcvc hdqkqhh bgkh ktpbgdn bgnqdk phvqslms hvtnftb qgvkhjb rsnmm fmsf gkjh bfgcms fvcqs mjcrg jsznqq cxltld jhl xdblc dmrnl qzffj kxqpgz nrvjmfb pnpfjb chhct gpmpf kpkrmx lrk msgzx rhbfl (contains soy, eggs)",
  "szgjf tfrlh rdhljms nkbq mdfnq xzfj msgzx pvvds cnm knzghq mht gsfx tsvrr gmsds sxlnzm fdgt vccmfr rhbfl lgvjd pqhqv jhl pdnqm ddsz bcss kjmxcb mpclb bnxp xpmx bbfkbl vgcxss nbn xnjx fvqmjdl qhgcvmm vnn scbhzv qgjfx fkcmf vbfqs tfgrk phvqslms kngjc mnrmrl jsznqq mrvp gxf jqdtgp bfgcms gjcvms fhbkt gnmsc bgkh klkdpk dqqnr dgv xdblc chcnqzx fmhsnr ndfb pfmfh nsfkkx zth rqrb vmc gkzgj hvtnftb hdqkqhh gqgds rqlslh qxqcg nbtgf mppgst vfjb ktpbgdn fmsf chhct pqqxxn ksbnxq (contains shellfish, soy, fish)",
  "nsfkkx nrmqlv ddsz bfgcms rxxmdp sqbvb hnnjms dmrnl tcp vgcxss kpkrmx jtkx hdqkqhh bnxp vfjb jsznqq htnhq kzlknls kfbpzd mppgst fjkbf kptrg sfhb qgjfx qfnbft dqqnr hmtkfnq vccmfr ndfb pvvds fmhsnr ktpbgdn zth xdblc fkcmf cxltld rnpll xsxnr xzfj jqrvm pqhqv pnpfjb csfflg nbtgf gsfx mnrmrl nrm fpmz fhbkt bcss nkbq gkjh qpkhl qpqtsn pssnm gpmpf zmxmr fqxdnm (contains sesame)",
  "bzhfdv bgnqdk fvcqs kxqpgz hscbd tfgrk xnjx ndfb pfmfh mcgs fkcmf pqqxxn kptrg ktpbgdn fvqmjdl jkvsmc hmtkfnq vnn hsqh ndnvm jzn bshlm xzfj mp hdqkqhh rdhljms fqxdnm lrk scsnf nbtgf pmvlzl fdgt pnpfjb pvvds tzlnd scbhzv vmhsj rxxmdp hvqxq mpclb htnhq qnzbpx xpmx jhl gkjh hpczjn sxlnzm qfnbft (contains sesame)",
  "cxltld xnkh ktpbgdn xzfj vfjb kptrg sdjnb bmgg msgzx bfgcms bzczpk gsfx nkxn mp nbn kfbpzd tfgrk rmdmc jhl mmkq pvvds vgcxss fvqmjdl fvcqs fkcmf pnpfjb kmmtz scsnf klkdpk nsfkkx xxthxs mppgst cnknqf klgbs tfrlh gnmsc jmzk hdqkqhh psscnhr ndfb jcqbsv fqxdnm (contains shellfish, wheat)",
  "pnpfjb bzczpk pbrds fvqhc gnmsc nrvjmfb scbhzv bfgcms rscgs xsxnr mpkk gkzgj cnm hsqh qtltm ndfb xzfj dxlzf qzffj rxxmdp psscnhr ktpbgdn rhbfl tcp rmdmc xxthxs rdhljms bcss hzhzdtd pkptv lxjmhz gpmpf jzn mmkq xnkh sdjnb pmvlzl hdqkqhh hmtkfnq mjcrg chhct tfrlh vmc vccmfr ndnvm mkpmz bgnqdk nbtgf ddzvfvq hktlnb kxbg (contains sesame)",
  "gtrffv rdhljms jkvsmc rsnmm vmhnvv kghrr xzfj kxbg qfnbft gjcvms xpmx nrvjmfb rqhrnm szgjf csfflg fpmz qxqcg ndnvm tfrlh mkpmz rmdmc sdjnb scmkv chhct ksbnxq htnhq nkbq bnfcvc vgcxss phvqslms kjmxcb bgkh msgzx pnpfjb jzn bbfkbl vfjb hnnjms ndfb knzghq mhbzd lgvjd szcfx jhl ckxrpj gxf gkzgj gqgds qzffj klkdpk fkcmf lrk qhgcvmm pdnqm fmhsnr mrvp hdqkqhh pkptv mht tsvrr bfgcms dktk xnjx cnm (contains peanuts)",
  "bmgg szgjf nrmqlv ddzvfvq rdhljms mltbpl vnn hnnjms pmvlzl xdblc nkbq tsvrr hdqkqhh ptjd kngjc hsqh tzlnd mpclb kghrr qhgcvmm mrvp scbhzv gmsds fkcmf lrk ksbnxq tcp pclxz fmhsnr rnpll jsznqq xpmx bfgcms fpmz ddsz gtrffv gnmsc vmc zth klkdpk rqlslh zgnxh vbfqs ktpbgdn hvtnftb qpkhl hscbd gkzgj pnpfjb fvcqs ndfb chcnqzx szcfx gsfx hvqxq jhl ndnvm kjmxcb sqbvb dgv bgnqdk znjlq mpkk csfflg (contains eggs)",
  "ctvdb gsfx ktpbgdn qzffj pnpfjb cxltld vnn bfgcms tfrlh rmdmc sfhb tsvrr fpmz bshlm hrnq gkzgj pclxz bnxp gpmpf xnjx lbhl ckxrpj fkcmf ksbnxq rdhljms sfsjpk qtltm dmrnl jkvsmc vccmfr pqhqv xzfj bmgg qgjfx bzczpk sdjnb jqdtgp jqrvm gxf bgkh kptrg jdkxx lxjmhz pkptv mcgs ptjd ddzvfvq xnkh jzn kngjc fgpkgp cnm hnnjms kjmxcb mdfnq ndnvm ndfb (contains sesame)",
  "tfgrk fpmz fgpkgp fkcmf bshlm fvqhc gxf jhl pfmfh jkvsmc hvtnftb bfgcms mnrmrl xzfj ndfb nbn kpkrmx jqdtgp hzhzdtd lgvjd kkffssg hdqkqhh qxqcg pnpfjb rnpll chhct zgnxh qzffj sfhb fmhsnr phvqslms ddsz pqhqv rdhljms (contains soy, wheat, fish)",
  "gmsds pdnqm zgnxh qnzbpx jqdtgp mltbpl pqqxxn jcqbsv gsfx qtltm kxqpgz mcgs rqhrnm pnpfjb scmkv fdgt mrvp mkpmz dqqnr bmgg vfjb qfnbft pclxz klgbs xnkh nsfkkx hrnq pkptv lrk ndfb hzhzdtd srv ktpbgdn vbfqs vnn lgvjd qhgcvmm trrqf hktlnb rqrb pbrds dmrnl phn szgjf bzhfdv bgkh jdkxx nrvjmfb xdblc jqrvm xdxdlsh pvvds vmhsj tzlnd kxbg gjcvms xsxnr gctpx sqbvb ndnvm fgpkgp ghmtfn rdhljms tsvrr xpmx mpclb qgjfx vccmfr bnfcvc xzfj xlqxvn nrmqlv fmhsnr kmmtz hvtnftb hvqxq gxf bfgcms kkffssg hdqkqhh hscbd pttsn jsznqq mhbzd sxlnzm htnhq (contains eggs)",
  "zmxmr cxltld dmrnl ndnvm bbfkbl nbn pfqjpf rdhljms rqhrnm srv hscbd tfrlh qhgcvmm gtrffv nrmqlv ndfb kgd klkdpk scbhzv lrk mp qgjfx qzffj vgcxss mmkq qpkhl cnm qfnbft vbfqs phn pnpfjb kptrg mjcrg nbtgf csfflg kkffssg knzghq lbhl nkbq fvqmjdl mht bgkh bnfcvc hnnjms hzhzdtd chcnqzx gsfx nrm lscrnr ktpbgdn rqlslh sxlnzm kzlknls hpczjn ksgpjv bgnqdk sfhb xzfj dxlzf nkxn vmc kfbpzd pmvlzl xsxnr bfgcms gkzgj xdxdlsh fkcmf mhbzd xdblc dqqnr hrnq sdjnb scsnf ddzvfvq kghrr fdgt fqxdnm (contains soy, peanuts)",
  "pdnqm tzlnd nsfkkx znjlq jzn jsznqq qfnbft szcfx jqdtgp mpclb csfflg chcnqzx hscbd hrnq ddzvfvq mltbpl ksgpjv lxjmhz mpkk lbhl ndfb dxlzf dgv bfgcms qnzbpx vfjb vmhnvv pqqxxn gpmpf kkffssg pnpfjb qgjfx nrvjmfb bgkh sqbvb xzfj fvqmjdl bnxp gkjh dmrnl kxbg tfgrk szgjf srv ktpbgdn mmkq ksbnxq bbfkbl xsxnr rqrb zth kxqpgz phn sxlnzm hvqxq pmvlzl xdxdlsh nrmqlv bshlm pfmfh sdjnb ghmtfn vnn bnfcvc fmhsnr cxltld nbn kpkrmx fpmz hdqkqhh gqgds fkcmf zgnxh bzhfdv tflck fvcqs xnkh cnknqf jcqbsv fdgt hpczjn hzhzdtd (contains wheat, dairy, eggs)",
  "pssnm qnzbpx xdblc xxthxs hpczjn pqqxxn qbgkhj znjlq jhl fvqmjdl fvcqs rdhljms hdqkqhh nbtgf pqhqv bshlm mjcrg lxjmhz qgjfx ndfb pdnqm kxbg hvqxq ghmtfn bfgcms pmvlzl kghrr fjkbf msgzx vbfqs xnjx ktpbgdn fkcmf xnkh mkpmz mdfnq gqgds trrqf bgkh mhbzd srv qzffj kngjc vgcxss ckxrpj sfsjpk scbhzv scsnf bgnqdk qgvkhjb rqlslh jmzk xzfj jkvsmc (contains wheat)",
  "qgjfx qpqtsn mppgst cxltld fvqhc vbfqs fkcmf jcqbsv sfsjpk qxqcg qhgcvmm ndfb xpmx mpkk kpkrmx scmkv trrqf gmsds bnxp zmxmr bgnqdk rdhljms chcnqzx lxjmhz rxxmdp bzczpk qgvkhjb kxqpgz hvqxq nrmqlv psscnhr fmsf hvtnftb kmmtz qtltm gnmsc bfgcms nkxn fvqmjdl xzfj jmzk zgnxh nrvjmfb mmkq pfqjpf sxlnzm pclxz ghmtfn szgjf bshlm bcss blgbtz nkbq ddzvfvq mht phn tzlnd pnpfjb qpkhl mnrmrl rnpll mpclb pdnqm xnjx kptrg bnfcvc hktlnb klgbs xxthxs fmhsnr qnzbpx kzlknls dqqnr ddsz pfmfh cnm ktpbgdn (contains sesame)",
  "mmkq mrvp rmdmc xsxnr blgbtz ktpbgdn hdqkqhh scbhzv lrk nbtgf bfgcms qfnbft rdhljms nrvjmfb sfsjpk ghmtfn kgd bbfkbl pfqjpf pnpfjb vbfqs sqbvb nkxn mcgs qxqcg szcfx rscgs fkcmf bshlm tflck jqrvm ndfb nkbq lscrnr jqdtgp ksgpjv kghrr hktlnb kzlknls lgvjd nrm psscnhr sfhb bzhfdv dktk scsnf (contains peanuts, shellfish)",
  "dktk bshlm kngjc pkptv ktpbgdn phn rqhrnm srv ndfb vgcxss tfgrk hrnq fkcmf nrvjmfb hdqkqhh lrk szcfx lgvjd cxltld mpclb scbhzv vmhnvv fdgt ddsz fqxdnm qpqtsn vnn bzhfdv sqbvb tcp mhbzd psscnhr znjlq knzghq pnpfjb jzn rnpll pttsn mjcrg ndnvm tzlnd gmsds fhbkt kgd mkpmz ksgpjv gtrffv scmkv blgbtz kzlknls htnhq bzczpk pqhqv hzhzdtd pclxz rdhljms bcss fpmz gqgds gjcvms nrmqlv rsnmm hscbd sfsjpk bfgcms jtkx lqvg xnkh nbn xpmx xdblc (contains wheat, eggs, dairy)",
  "hsqh gxf psscnhr ndfb vmc qzffj lbhl fdgt xzfj jhl sfhb cnknqf mp bshlm jkvsmc knzghq pqqxxn jcqbsv fvqmjdl cxltld fpmz qpkhl fvcqs mmkq dgv pfqjpf mhbzd qnzbpx cnm ndnvm jtkx dxlzf fvqhc vgcxss sxlnzm gkjh sqbvb gjcvms xxthxs hmtkfnq hktlnb trrqf fjkbf ptjd ktpbgdn gnmsc rmdmc gctpx zgnxh mpkk csfflg qhgcvmm bnfcvc xpmx xdxdlsh qgjfx chhct nrvjmfb jmzk gtrffv kxbg fkcmf qbgkhj rsnmm rdhljms kngjc pnpfjb bfgcms klgbs gkzgj (contains sesame, peanuts)",
];

function Day21() {
  const allIngredientOccurances: string[] = [];
  const ingredientsByAllergen: { [allergen: string]: string[] } = {};

  input.forEach((line) => {
    const ingredientsAndAllergens = line.split(" (contains ");
    const ingredients = ingredientsAndAllergens[0].split(" ");
    const allergens = ingredientsAndAllergens[1].slice(0, -1).split(", ");

    allIngredientOccurances.push(...ingredients);

    allergens.forEach((allergen) => {
      if (!ingredientsByAllergen[allergen]) {
        ingredientsByAllergen[allergen] = ingredients;
      } else {
        ingredientsByAllergen[allergen] = ingredients.filter((newIngredient) =>
          ingredientsByAllergen[allergen].some(
            (existingIngredient) => newIngredient === existingIngredient
          )
        );
      }
    });
  });

  let ingredientsWithKnownAllergen: string[] = [];
  let toRemove: string[] = [];

  const ingredientsToRemove = (): boolean => {
    ingredientsWithKnownAllergen = Object.values(ingredientsByAllergen)
      .filter((ingredients) => ingredients.length === 1)
      .map((ingredients) => ingredients[0]);

    if (
      ingredientsWithKnownAllergen &&
      ingredientsWithKnownAllergen.length > 0
    ) {
      toRemove = Object.entries(ingredientsByAllergen)
        .filter(
          ([, ingredients]) =>
            ingredients.length > 1 &&
            ingredients.some((i) =>
              ingredientsWithKnownAllergen.find((ki) => ki === i)
            )
        )
        .map(([allergen]) => allergen);
      return toRemove.length > 0;
    } else {
      return false;
    }
  };

  while (ingredientsToRemove()) {
    // eslint-disable-next-line no-loop-func
    toRemove.forEach((allergen: string) => {
      ingredientsByAllergen[allergen] = ingredientsByAllergen[allergen].filter(
        (i) => !ingredientsWithKnownAllergen?.some((ki) => ki === i)
      );
    });
  }

  const ingredientsWithoutKnownAllergens = allIngredientOccurances.filter(
    (i) => !ingredientsWithKnownAllergen.some((ki) => ki === i)
  );
  const sortedDangerousIngredients = Object.keys(ingredientsByAllergen)
    .sort()
    .map((allergen) => ingredientsByAllergen[allergen][0]);

  return (
    <div>
      <h2>Day 21</h2>
      <p>
        There are {ingredientsWithoutKnownAllergens.length} ingredients which
        cannot contain known allergens in part 1
      </p>
      <p>
        The dangerous ingregients list in part 2 is{" "}
        {sortedDangerousIngredients.join(",")}
      </p>
    </div>
  );
}

export default Day21;
