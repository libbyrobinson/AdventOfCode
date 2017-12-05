using System;
using System.Linq;

namespace AdventOfCode
{
    public class Day5_TwistyTrampolines
    {
        private string _rawData = "1\r\n0\r\n0\r\n1\r\n0\r\n-3\r\n-3\r\n-6\r\n0\r\n-7\r\n-9\r\n0\r\n-2\r\n0\r\n-8\r\n-1\r\n-15\r\n-15\r\n-4\r\n-12\r\n-19\r\n-3\r\n-12\r\n-10\r\n-3\r\n-17\r\n-17\r\n-9\r\n-18\r\n-20\r\n-1\r\n-6\r\n-29\r\n-18\r\n-5\r\n-25\r\n-13\r\n-22\r\n-33\r\n2\r\n-39\r\n-40\r\n-33\r\n-33\r\n-27\r\n-7\r\n-44\r\n1\r\n-20\r\n-46\r\n-41\r\n0\r\n-19\r\n0\r\n-10\r\n-15\r\n-21\r\n-17\r\n-52\r\n-20\r\n-45\r\n-34\r\n-30\r\n-29\r\n-40\r\n-1\r\n-18\r\n-10\r\n-19\r\n-15\r\n-64\r\n-61\r\n-53\r\n-28\r\n-45\r\n-12\r\n-73\r\n-36\r\n-36\r\n-2\r\n-30\r\n-56\r\n-63\r\n-42\r\n-8\r\n-35\r\n-32\r\n-39\r\n-22\r\n-87\r\n-45\r\n-35\r\n-74\r\n1\r\n-5\r\n-45\r\n-16\r\n-19\r\n-48\r\n-25\r\n-94\r\n-85\r\n-75\r\n-15\r\n-79\r\n-37\r\n-82\r\n-13\r\n-85\r\n-20\r\n-52\r\n-50\r\n-85\r\n-13\r\n-70\r\n-16\r\n-86\r\n0\r\n-68\r\n-55\r\n-15\r\n-25\r\n-31\r\n-117\r\n-91\r\n-67\r\n-114\r\n-108\r\n-50\r\n-76\r\n-116\r\n-12\r\n-27\r\n-98\r\n-115\r\n-101\r\n-124\r\n-2\r\n-4\r\n-95\r\n-41\r\n-35\r\n-110\r\n-86\r\n-4\r\n-126\r\n-67\r\n-94\r\n-81\r\n-101\r\n-93\r\n-109\r\n-71\r\n-152\r\n-110\r\n-145\r\n-28\r\n-139\r\n-106\r\n-83\r\n-58\r\n-100\r\n-1\r\n-21\r\n-112\r\n-130\r\n-102\r\n-34\r\n-80\r\n-49\r\n-11\r\n-72\r\n-82\r\n-132\r\n-36\r\n-119\r\n-127\r\n-85\r\n-66\r\n-12\r\n-43\r\n-3\r\n-86\r\n-116\r\n-125\r\n-162\r\n0\r\n-185\r\n-39\r\n-27\r\n-159\r\n-23\r\n-71\r\n-50\r\n-119\r\n-183\r\n-56\r\n-48\r\n-113\r\n-197\r\n-199\r\n-6\r\n-92\r\n-7\r\n-39\r\n-63\r\n-67\r\n-22\r\n-126\r\n-170\r\n-67\r\n-59\r\n-114\r\n-207\r\n-13\r\n-15\r\n-168\r\n-167\r\n-15\r\n-143\r\n-128\r\n-136\r\n-115\r\n2\r\n-113\r\n-74\r\n-104\r\n-91\r\n-157\r\n-121\r\n-126\r\n-125\r\n-112\r\n-106\r\n-194\r\n-146\r\n-165\r\n-139\r\n-97\r\n-134\r\n-133\r\n-165\r\n-237\r\n-69\r\n-10\r\n-232\r\n-100\r\n-168\r\n-53\r\n-83\r\n-149\r\n-42\r\n-71\r\n-119\r\n-185\r\n-110\r\n-92\r\n-256\r\n-19\r\n-249\r\n-147\r\n-68\r\n-205\r\n-52\r\n-212\r\n-5\r\n-167\r\n-63\r\n-264\r\n-176\r\n-180\r\n-223\r\n-15\r\n-158\r\n-2\r\n-134\r\n-268\r\n-92\r\n-193\r\n-145\r\n-141\r\n-218\r\n-99\r\n-85\r\n-213\r\n-24\r\n-82\r\n-201\r\n-109\r\n0\r\n-152\r\n-14\r\n-168\r\n-103\r\n-232\r\n-7\r\n-115\r\n-141\r\n-273\r\n-117\r\n-201\r\n-165\r\n-265\r\n-81\r\n-64\r\n-243\r\n-123\r\n0\r\n-24\r\n-140\r\n-235\r\n-194\r\n-11\r\n-129\r\n-128\r\n-211\r\n-59\r\n-97\r\n-40\r\n-76\r\n-104\r\n-38\r\n-312\r\n-225\r\n-93\r\n-113\r\n-108\r\n-109\r\n-22\r\n-128\r\n-250\r\n-222\r\n-262\r\n-214\r\n-34\r\n-87\r\n-176\r\n-166\r\n-33\r\n-226\r\n-198\r\n-238\r\n-159\r\n-295\r\n-245\r\n-227\r\n-211\r\n-59\r\n-237\r\n-74\r\n-92\r\n-221\r\n-118\r\n-77\r\n-160\r\n-110\r\n-260\r\n-259\r\n-25\r\n-117\r\n-120\r\n-304\r\n-273\r\n-89\r\n-354\r\n-85\r\n-339\r\n-366\r\n-46\r\n-91\r\n-280\r\n-68\r\n-62\r\n-118\r\n-178\r\n-249\r\n-281\r\n-273\r\n-360\r\n-356\r\n-150\r\n-367\r\n-47\r\n-289\r\n-51\r\n-233\r\n-158\r\n-226\r\n-372\r\n-212\r\n-139\r\n-119\r\n-238\r\n-244\r\n-39\r\n-263\r\n-239\r\n-374\r\n-257\r\n-146\r\n-347\r\n-209\r\n-350\r\n2\r\n-403\r\n-149\r\n-381\r\n-55\r\n-114\r\n-294\r\n-106\r\n-118\r\n-222\r\n-24\r\n-259\r\n-301\r\n-357\r\n-13\r\n-137\r\n-281\r\n-88\r\n-7\r\n-276\r\n2\r\n-7\r\n-232\r\n-337\r\n-172\r\n-181\r\n-129\r\n-51\r\n-147\r\n-310\r\n-253\r\n-396\r\n-111\r\n-386\r\n-106\r\n-240\r\n-432\r\n-94\r\n-239\r\n-334\r\n-135\r\n-196\r\n-329\r\n-228\r\n-10\r\n-438\r\n-419\r\n-86\r\n-167\r\n-56\r\n-200\r\n-69\r\n-229\r\n-90\r\n-147\r\n-160\r\n-345\r\n-7\r\n-96\r\n-251\r\n-113\r\n-53\r\n-186\r\n-426\r\n-244\r\n-185\r\n-178\r\n-267\r\n-378\r\n-368\r\n-53\r\n-424\r\n-178\r\n-179\r\n-353\r\n-242\r\n-182\r\n-423\r\n-139\r\n-49\r\n-335\r\n-225\r\n-3\r\n-13\r\n-159\r\n-245\r\n-244\r\n-359\r\n-223\r\n-380\r\n-264\r\n-383\r\n-285\r\n-322\r\n-471\r\n-7\r\n-295\r\n-84\r\n-291\r\n-92\r\n-129\r\n-175\r\n-205\r\n-49\r\n-164\r\n-262\r\n-105\r\n-364\r\n-438\r\n-283\r\n-415\r\n-323\r\n-167\r\n-501\r\n-22\r\n-428\r\n-10\r\n-156\r\n-517\r\n-385\r\n-356\r\n-396\r\n-295\r\n-372\r\n-409\r\n-311\r\n-261\r\n-262\r\n-4\r\n-41\r\n-264\r\n-436\r\n-316\r\n-22\r\n-449\r\n-444\r\n-306\r\n-324\r\n-16\r\n-431\r\n-379\r\n-476\r\n-369\r\n-198\r\n-312\r\n-393\r\n-47\r\n-277\r\n-523\r\n-402\r\n-368\r\n-312\r\n-418\r\n-21\r\n-372\r\n-86\r\n-286\r\n-475\r\n-183\r\n-405\r\n-427\r\n-404\r\n-405\r\n-446\r\n-549\r\n-296\r\n-249\r\n-243\r\n-472\r\n-450\r\n-126\r\n-260\r\n-227\r\n-25\r\n-348\r\n-122\r\n-80\r\n-330\r\n-222\r\n-389\r\n-360\r\n-250\r\n-310\r\n-544\r\n-113\r\n-556\r\n-445\r\n-457\r\n-533\r\n-447\r\n-251\r\n-373\r\n-343\r\n-391\r\n-12\r\n-567\r\n-128\r\n-332\r\n-245\r\n-252\r\n-517\r\n-101\r\n-480\r\n-401\r\n-290\r\n-394\r\n-321\r\n-533\r\n-257\r\n-102\r\n-152\r\n-251\r\n-102\r\n-507\r\n-597\r\n-175\r\n-345\r\n-442\r\n-600\r\n-306\r\n-149\r\n-151\r\n-355\r\n-71\r\n-315\r\n-35\r\n-161\r\n-404\r\n-253\r\n-526\r\n-275\r\n-339\r\n-483\r\n-315\r\n-423\r\n-116\r\n-345\r\n-507\r\n-332\r\n-27\r\n-395\r\n-634\r\n-548\r\n-205\r\n-276\r\n-213\r\n-356\r\n-413\r\n-353\r\n-89\r\n-88\r\n-649\r\n-465\r\n-580\r\n-286\r\n-607\r\n-21\r\n-35\r\n-227\r\n-415\r\n-501\r\n-343\r\n-245\r\n-94\r\n-200\r\n-376\r\n-43\r\n-585\r\n-668\r\n-623\r\n-264\r\n-574\r\n-223\r\n-628\r\n-556\r\n-100\r\n-53\r\n-88\r\n-644\r\n-285\r\n-631\r\n-418\r\n-369\r\n-477\r\n-379\r\n-199\r\n-68\r\n-323\r\n-337\r\n-318\r\n-651\r\n-255\r\n-323\r\n-38\r\n-502\r\n-356\r\n-550\r\n-555\r\n-679\r\n-170\r\n-38\r\n-516\r\n-367\r\n-687\r\n-52\r\n-23\r\n-225\r\n-451\r\n-323\r\n-637\r\n-264\r\n0\r\n-535\r\n-67\r\n-254\r\n-580\r\n-173\r\n-301\r\n-374\r\n-120\r\n-8\r\n-197\r\n-154\r\n-173\r\n-597\r\n-525\r\n-341\r\n-278\r\n-721\r\n-360\r\n-728\r\n-607\r\n-346\r\n-491\r\n-247\r\n2\r\n-121\r\n-505\r\n-694\r\n-706\r\n-297\r\n-4\r\n-110\r\n-187\r\n-259\r\n-414\r\n-323\r\n-637\r\n-96\r\n-157\r\n-331\r\n-521\r\n-590\r\n-390\r\n-220\r\n-100\r\n-156\r\n-302\r\n-545\r\n-322\r\n-450\r\n-236\r\n-287\r\n-605\r\n-346\r\n-467\r\n-25\r\n-382\r\n-430\r\n-682\r\n2\r\n-261\r\n-605\r\n-635\r\n-633\r\n-553\r\n-491\r\n-226\r\n-622\r\n-191\r\n-48\r\n-92\r\n-218\r\n-548\r\n-651\r\n-672\r\n-631\r\n-764\r\n-367\r\n-108\r\n-507\r\n-790\r\n-573\r\n-282\r\n-334\r\n-280\r\n-285\r\n-105\r\n-797\r\n-228\r\n-85\r\n-102\r\n-623\r\n-304\r\n-52\r\n-278\r\n-243\r\n-681\r\n-133\r\n-606\r\n-345\r\n-354\r\n-402\r\n-6\r\n-353\r\n-447\r\n-69\r\n-432\r\n-54\r\n-486\r\n-78\r\n-774\r\n-241\r\n-625\r\n-806\r\n-425\r\n-790\r\n-381\r\n-507\r\n-755\r\n-304\r\n-362\r\n-606\r\n-256\r\n-25\r\n-341\r\n-451\r\n-12\r\n-606\r\n-738\r\n-484\r\n-167\r\n-663\r\n1\r\n-481\r\n-788\r\n-469\r\n-388\r\n-59\r\n-105\r\n-402\r\n-523\r\n-717\r\n-234\r\n-611\r\n-543\r\n-435\r\n-383\r\n-267\r\n-217\r\n-275\r\n-610\r\n-335\r\n-411\r\n-842\r\n-131\r\n-460\r\n-527\r\n-511\r\n-761\r\n-160\r\n-660\r\n-605\r\n-817\r\n-546\r\n-286\r\n-604\r\n-204\r\n-223\r\n-558\r\n-652\r\n-542\r\n-350\r\n-527\r\n-59\r\n-782\r\n-764\r\n-529\r\n-608\r\n-688\r\n-301\r\n-715\r\n-148\r\n-492\r\n-796\r\n-285\r\n-491\r\n-702\r\n-767\r\n-191\r\n-572\r\n-712\r\n-207\r\n-589\r\n-39\r\n-278\r\n-485\r\n-273\r\n-51\r\n-560\r\n-718\r\n-790\r\n0\r\n-194\r\n-319\r\n-171\r\n-552\r\n-247\r\n-810\r\n-737\r\n-677\r\n-853\r\n-806\r\n-565\r\n-923\r\n-427\r\n-442\r\n-375\r\n-215\r\n-706\r\n-139\r\n-396\r\n-126\r\n-170\r\n-281\r\n-544\r\n-101\r\n-271\r\n-728\r\n-485\r\n-677\r\n-442\r\n-137\r\n-78\r\n-414\r\n-546\r\n-669\r\n-609\r\n-284\r\n-488\r\n-181\r\n-534\r\n-946\r\n-191\r\n-255\r\n-413\r\n-614\r\n-329\r\n-932\r\n-528\r\n-689\r\n-246\r\n-272\r\n-395\r\n-211\r\n-702\r\n-786\r\n-595\r\n-835\r\n-870\r\n-822\r\n-507\r\n-533\r\n-147\r\n-141\r\n-385\r\n-623\r\n-745\r\n-575\r\n-225\r\n-79\r\n-736\r\n-887\r\n-649\r\n-133\r\n-500\r\n-422\r\n-810\r\n-491\r\n-480\r\n-462\r\n-16\r\n-848\r\n-740\r\n-809\r\n-9\r\n-399\r\n-535\r\n-274\r\n-165\r\n-119\r\n-77\r\n-340\r\n-597\r\n-755\r\n-611\r\n-929\r\n-50\r\n-745\r\n-530\r\n-392\r\n-77\r\n-760\r\n-961\r\n-28\r\n-507\r\n-21\r\n-253\r\n-846\r\n-996\r\n-308\r\n-175\r\n-684\r\n-315\r\n-859\r\n-757\r\n-418\r\n-591\r\n-946\r\n-393\r\n-25\r\n-917\r\n-208\r\n-572";

        public int CountStepsToExit_Part1()
        {
            var numberOfJumps = 0;

            var jumpOffsets = _rawData.Split(new[] {"\r\n"}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var currentIndex = 0;
            while (currentIndex >= 0 && currentIndex < jumpOffsets.Length)
            {
                numberOfJumps++;
                var currentJump = jumpOffsets[currentIndex];
                jumpOffsets[currentIndex]++;
                currentIndex = currentIndex + currentJump;
            }

            return numberOfJumps;
        }

        public int CountStepsToExit_Part2()
        {
            var numberOfJumps = 0;

            var jumpOffsets = _rawData.Split(new[] { "\r\n" }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var currentIndex = 0;
            while (currentIndex >= 0 && currentIndex < jumpOffsets.Length)
            {
                numberOfJumps++;
                var currentJump = jumpOffsets[currentIndex];
                if (currentJump >= 3)
                {
                    jumpOffsets[currentIndex]--;
                }
                else
                {
                    jumpOffsets[currentIndex]++;
                }
                currentIndex = currentIndex + currentJump;
            }

            return numberOfJumps;
        }
    }
}